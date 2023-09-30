using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Authenticate.Commands.SignIn;
using App.Application.Authenticate.Dtos;
using App.Application.Common.Dtos;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces.Services.Members;
using App.Application.Features.EmailAccount;
using App.Application.Features.EmailPassword;
using App.Application.Features.FindAccount;
using App.Application.Features.PhoneAccount;
using App.Application.Features.PhonePassword;
using App.Application.Features.ResetPassword;
using App.Application.Features.SendVerificationCode;
using App.Application.Features.SignUp;
using App.Application.Features.UpdatePassword;
using App.Application.Managements.AspnetUsers.Queries.FindAspnetUser;
using App.Application.Managements.Privileges.Dtos;
using App.Application.Managements.Privileges.Queries.QueryPrivilege;
using App.Application.Managements.Users.Commands.DeleteUser;
using App.Application.Managements.Users.Dtos;
using App.Application.Managements.Users.Queries.FetchAllUser;
using App.Application.Managements.Users.Queries.FindUser;
using App.Application.Managements.Users.Queries.QueryUser;
using App.Domain.Entities.Features;
using App.Infrastructure.Dtos.WebApis;
using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Yozian.Extension.Pagination;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 會員
    /// </summary>
    [Route("api/[controller]")]
    [Auth]
    public class UserController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;
        private readonly IGammaModMemberService gammaModMemberService;

        public UserController(
            VerificationCodeService verificationCodeService,
            IGammaModMemberService gammaModMemberService
        )
        {
            this.verificationCodeService = verificationCodeService;
            this.gammaModMemberService = gammaModMemberService;
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("signin")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<SignInResponse>> Signin(
            [FromBody] SignInCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<SignInResponse>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 取得驗證碼
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("verification/code")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<VerificationCodeResponse>> GetVerificationCode()
        {
            var data = await this.verificationCodeService.CreateVerificationCode();

            return new ApiResponse<VerificationCodeResponse>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 尋找帳號 輸入EMail 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("account")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<FindAccountResponse>> FindAccount([FromQuery] FindAccountCommand request)
        {
            //1. 通過 Email 拿到  MOD_MEMBER.IDENTIFIER （Account = IDENTIFIER)
            var data = await this.Mediator.Send(request);

            //2. 這裡如果沒有找到Email，會返回Account = null，要加上業務邏輯檢驗
            if (string.IsNullOrEmpty(data.Account))
            {
                throw new MyBusinessException("查無帳號資訊");
            }

            //3. 呼叫FindAspnetUserRequestHandler.Handle（在Application層中）
            // FindAspnetUserRequestValidator驗證中，有要求Id > 0的，暫時保留這個驗證，
            // 送個1到後面，不會使用這個Id欄位當條件

            var user = await this.Mediator.Send(
                new FindAspnetUserRequest
                {
                    Id = 1,
                    UserName = data.Account
                }
            );

            //4. 這裡一般會加一些 user不存在的判定，但是由於 FindAspnetUserRequestHandler.Handle
            //   使用了 FindOneAsync()，會對null進行throw的動作，即返回一個【不存在】提示，
            //   所以 null的check，可以跳過。非 null的邏輯判定如果有，也需要在這裡寫。
            //   如： user.xxxx != xxxx 會給提示這類業務邏輯的判定。

            //if (data.Account < 1)
            //{
            //    throw new MyBusinessException("查無帳號資訊");
            //}

            //5. 這裡返回的就是 （1）查出的 IDENTIFIER
            return new ApiResponse<FindAccountResponse>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("signup")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<SignUpCommandResponse>> SignUp([FromBody] SignUpCommand request)
        {
            if (!string.IsNullOrEmpty(request.IdNumber)
                && (await this.Mediator.Send(
                    new FetchAllUserRequest
                    {
                        IdNumber = request.IdNumber
                    }
                )).Any())
            {
                throw new MyBusinessException("此帳號已註冊過");
            }

            if (!string.IsNullOrEmpty(request.CellPhone)
                && (await this.Mediator.Send(
                    new FetchAllUserRequest
                    {
                        CellPhone = request.CellPhone
                    }
                )).Any())
            {
                throw new MyBusinessException("此手機已註冊過");
            }

            if (!string.IsNullOrEmpty(request.Email1)
                && (await this.Mediator.Send(
                    new FetchAllUserRequest
                    {
                        Email1 = request.Email1
                    }
                )).Any())
            {
                throw new MyBusinessException("此信箱已註冊過");
            }

            var data = await this.Mediator.Send(request);

            return new ApiResponse<SignUpCommandResponse>() //必須修正為SignUpUpdateCommandResponse
            {
                Data = data
            };
        }

        /// <summary>
        /// 舊用戶註冊
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation("updateMember")]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("signup/{id:int?}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<SignUpCommandResponse>> UpdateMember(int? id, [FromBody] SignUpCommand request)
        {
            request.Id = id;
            var data = await this.Mediator.Send(request);

            return new ApiResponse<SignUpCommandResponse>() //必須修正為SignUpUpdateCommandResponse
            {
                Data = data
            };
        }

        /// <summary>
        /// 以 Id 查詢用戶資料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<UserView>> GetUser([FromRoute] FindUserRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UserView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 發送 Email/SMS 驗證碼
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("verification/code")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<SendVerificationCodeResponse>> SendVerification(
            SendVerificationCodeRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            Random random = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                sb.Append(random.Next(0, 9));
            }


            if (request.ResetType.ToString().ToUpper() == "EMAIL" && request.Account.Contains("@"))
            {
                this.SendMail(request.Account, request.Account, "系統驗證碼", $"系統驗證碼：{sb.ToString()}");
            }
            else
            {
                var PhoneNumber = request.Account;
                if (PhoneNumber.First() == '+')
                {
                    PhoneNumber = request.Account.Substring(1);
                }
                else if (PhoneNumber.First() == '0')
                {
                    PhoneNumber = "886" + PhoneNumber.Substring(1);
                }

                var sms = new SMSHttp();
                var smsId = "gamma";
                var smsPw = "Admin@1234";
                sms.sendSMS(smsId, smsPw, "系統驗證碼", $"系統驗證碼：{sb.ToString()}", "",
                            "+" + PhoneNumber, "", "", "", false, false, false);               
            }

            data.Token = sb.ToString();
            return new ApiResponse<SendVerificationCodeResponse>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 使用 Email or SMS 修改密碼
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("password")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<ResetPasswordCommandResponse>> ResetPassword(ResetPasswordCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<ResetPasswordCommandResponse>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 登入後-以 id 修改密碼
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("update/password")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<UpdatePasswordCommandResponse>> UpdatePassword(UpdatePasswordCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<UpdatePasswordCommandResponse>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢會員列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<UserView>>> QueryUsers(
            [FromBody] QueryUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<UserView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢會員列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query/anonymous")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<Page<UserView>>> AnonymousQueryUsers(
            [FromBody] QueryUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<UserView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢會員列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<UserView>>> FindUsers(
            [FromQuery] QueryUserRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<UserView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<int>> RemoveUser([FromRoute] DeleteUserCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<int>()
            {
                Data = 1
            };
        }
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("userprivilege")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<PrivilegeView>>> QueryUserPrivilege([FromBody] QueryUserPrivilegeRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<PrivilegeView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 忘記帳號=>前端輸入Email=>後端驗證=>發MAIL給客戶 Get user/emailaccount
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("emailaccount")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<EmailAccountResponse>> EmailAccount([FromQuery] EmailAccountCommand request)
        {
            var data = await this.Mediator.Send(request);

            if (string.IsNullOrEmpty(data.Name))
            {
                throw new MyBusinessException("查無帳號資訊");
            }
            this.SendMail(data.Email, data.Name, "忘記帳號", $"您的帳號：{data.Account}");

            return new ApiResponse<EmailAccountResponse>()
            {
                Data = data
            };
        }



        /// <summary>
        /// 忘記密碼=>前端輸入Email=>後端驗證=>發MAIL給客戶 Get user/emailpassword
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("emailpassword")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<EmailPasswordResponse>> EmailPassword([FromQuery] EmailPasswordCommand request)
        {
            var data = await this.Mediator.Send(request);

            if (string.IsNullOrEmpty(data.Name))
            {
                throw new MyBusinessException("查無帳號資訊");
            }
            if (string.IsNullOrEmpty(data.Password))
            {
                throw new MyBusinessException("密碼產生錯誤");
            }
            this.SendMail(data.Email, data.Name, "密碼重置", $"您的密碼重置：{data.Password}");

            return new ApiResponse<EmailPasswordResponse>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 忘記帳號=>前端輸入電話=>後端驗證=>發SMS給客戶  Get user/smsaccount
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("smsaccount")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<PhoneAccountResponse>> SMSAccount([FromQuery] PhoneAccountCommand request)
        {
            var data = await this.Mediator.Send(request);

            if (string.IsNullOrEmpty(data.Name))
            {
                throw new MyBusinessException("查無帳號資訊");
            }

            var sms = new SMSHttp();
            var smsId = "gamma";
            var smsPw = "Admin@1234";
            sms.sendSMS(smsId, smsPw, "忘記帳號", $"您的帳號：{data.Account}", "", 
                        "+" + data.Phone, "", "", "", false, false, false);

            return new ApiResponse<PhoneAccountResponse>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 忘記密碼=>前端輸入Phone=>後端驗證=>發SMS給客戶  Get user/smspassword
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("smspassword")]
        [ResponseCache(NoStore = true, Duration = -1)]
        [AllowAnonymous]
        public async Task<ApiResponse<PhonePasswordResponse>> PhonePassword([FromQuery] PhonePasswordCommand request)
        {
            var data = await this.Mediator.Send(request);

            if (string.IsNullOrEmpty(data.Name))
            {
                throw new MyBusinessException("查無帳號資訊");
            }
            if (string.IsNullOrEmpty(data.Password))
            {
                throw new MyBusinessException("密碼產生錯誤");
            }

            var sms = new SMSHttp();
            var smsId = "gamma";
            var smsPw = "Admin@1234";
            sms.sendSMS(smsId, smsPw, "密碼重置", $"您的密碼重置：{data.Password}", "",
                        "+" + data.Phone, "", "", "", false, false, false);

            return new ApiResponse<PhonePasswordResponse>()
            {
                Data = data
            };
        }

        /// <summary>
        /// Send Mail
        /// </summary>
        /// <param name="toMail"></param>
        /// <param name="toName"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private string SendMail(string toMail, string toName, string subject, string body)
        {
            try
            {
                var fromAddress = new MailAddress("bannerchurch22@gmail.com", "教會系統服務");
                var fromPassword = "rgwwqagxmmbqvkkf";

                //這邊改成 忘記帳號人的Request.Mail跟 對應到的User.Name
                //var ToMail = Request.Mail;
                //var ToName = select Name from User where Email1 = '"+Request.Mail+"';


                var toAddress = new MailAddress(toMail, toName);
                //---------------------


                //var fromAddress = new MailAddress("allens0426@gmail.com", "教會系統服務");
                //var toAddress = new MailAddress("allens0426@gmail.com", "ALLEN");
                //const string fromPassword = "lxeyiqdmzieppnhj";//"Bannerchurch@2022";
                //const string subject = "忘記帳號";
                //const string body = "您的帳號=>OOOOO";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                };
                smtp.Send(message);
                return "";


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        /// <summary>
        /// Send SMS
        /// </summary>
        /// <param name="toPhone"></param>
        /// <param name="toName"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private string SendSMS(string toPhone, string toName, string subject, string body)
        {
            try
            {
                //string accountSid = Environment.GetEnvironmentVariable("ACc8a34f007f5396da750b5e5720aa4a99");
                //string authToken = Environment.GetEnvironmentVariable("ceeab4e8d353acc5dac7b40baa93373d");
                string accountSid = "ACc8a34f007f5396da750b5e5720aa4a99";
                string authToken = "ceeab4e8d353acc5dac7b40baa93373d";

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                           body: body,
                           from: new Twilio.Types.PhoneNumber("+886982261987"),
                           to: new Twilio.Types.PhoneNumber("+886982271987")
                   );

                Console.WriteLine(message.Sid);



                return "";


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }

    /// <summary>
    /// SMS
    /// </summary>
    public class SMSHttp
    {
        private string sendSMSUrl = "https://api.e8d.tw/API21/HTTP/sendSMS.ashx";
        private string sendParamSMSUrl = "https://api.e8d.tw/API21/HTTP/SendParamSMS.ashx";
        private string sendMMSUrl = "https://api.e8d.tw/API21/HTTP/MMS/sendMMS.ashx";
        private string getCreditUrl = "https://api.e8d.tw/API21/HTTP/getCredit.ashx";
        private string processMsg = "";
        private string batchID = "";
        private double credit = 0;

        public SMSHttp()
        {
        }

        /// <summary>
        /// 傳送簡訊
        /// </summary>
        /// <param name="userID">帳號</param>
        /// <param name="password">密碼</param>
        /// <param name="subject">簡訊主旨，主旨不會隨著簡訊內容發送出去。用以註記本次發送之用途。可傳入空字串。</param>
        /// <param name="content">簡訊發送內容(SMS一般、SMS參數、MMS一般簡訊需填寫)</param>
        /// <param name="param">簡訊Param內容(參數、個人化(專屬)簡訊需填寫Json格式)</param>
        /// <param name="mobile">接收人之手機號碼。格式為: +886900000001。多筆接收人時，請以半形逗點隔開( , )，如+886900000001,+886900000002。</param>
        /// <param name="sendTime">簡訊預定發送時間。-立即發送：請傳入空字串。-預約發送：請傳入預計發送時間，若傳送時間小於系統接單時間，將不予傳送。格式為YYYYMMDDhhmnss；例如:預約2009/01/31 15:30:00發送，則傳入20090131153000。若傳遞時間已逾現在之時間，將立即發送。</param>
        /// <param name="attachment">image base64</param>
        /// <param name="type">圖檔副檔名</param>
        /// <param name="isParam">是否為SMS參數簡訊</param>
        /// <param name="isPersonal">是否為SMS個人化(專屬)簡訊</param>
        /// <param name="isMMS">是否為MMS一般簡訊</param>
        /// <returns>true:傳送成功；false:傳送失敗</returns>
        public bool sendSMS(string userID, string password, string subject, string content, string param, string mobile, string sendTime, string attachment, string type, bool isParam, bool isPersonal, bool isMMS)
        {
            bool success = false;
            StringBuilder postDataSb = new StringBuilder();
            string resultString = string.Empty;
            string[] split = null;

            try
            {
                #region UrlEncode
                subject = !isParam && !isPersonal ? HttpUtility.UrlEncode(subject) : subject;
                content = !isParam && !isPersonal ? HttpUtility.UrlEncode(content) : content;
                mobile = !isParam && !isPersonal ? HttpUtility.UrlEncode(mobile) : mobile;
                attachment = isMMS ? HttpUtility.UrlEncode(attachment) : attachment;
                #endregion

                #region 檢查時間格式
                if (!string.IsNullOrEmpty(sendTime))
                {
                    try
                    {
                        //檢查傳送時間格式是否正確
                        DateTime checkDt = DateTime.ParseExact(sendTime, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                        if (!sendTime.Equals(checkDt.ToString("yyyyMMddHHmmss")))
                        {
                            processMsg = "傳送時間格式錯誤";
                            return success;
                        }
                    }
                    catch
                    {
                        processMsg = "傳送時間格式錯誤";
                        return success;
                    }
                }
                #endregion

                #region SMS一般簡訊
                if (!isParam && !isPersonal && !isMMS)
                {
                    postDataSb.Append("UID=").Append(userID);
                    postDataSb.Append("&PWD=").Append(password);
                    postDataSb.Append("&SB=").Append(subject);
                    postDataSb.Append("&MSG=").Append(content);
                    postDataSb.Append("&DEST=").Append(mobile);
                    postDataSb.Append("&ST=").Append(sendTime);
                    resultString = httpPost(sendSMSUrl, postDataSb.ToString(), false);
                }
                #endregion

                #region SMS參數簡訊
                if (isParam)
                {
                    //「發送內容」範例(msg)：測試%field1%%field2%
                    //「Param內容」範例(param)：[{"Name":"test_A","Mobile":"+886900000001","Email":"testA@test.com.tw","SendTime":"29990109083000","Param":"A1|A2|||"},{"Name":"test_B","Mobile":"+886900000002","Email":"testB@test.com.tw","SendTime":"29990125173000","Param":"B1|B2|||"}]
                    postDataSb.Append("{\"UID\":\"").Append(userID).Append("\",");
                    postDataSb.Append("\"PWD\":\"").Append(password).Append("\",");
                    postDataSb.Append("\"SB\":\"").Append(subject).Append("\",");
                    postDataSb.Append("\"MSG\":\"").Append(content).Append("\",");
                    postDataSb.Append("\"RecipientDataList\":").Append(param).Append("}");
                    resultString = httpPost(sendParamSMSUrl, postDataSb.ToString(), isParam);
                }
                #endregion

                #region SMS個人化(專屬)簡訊
                if (isPersonal)
                {
                    //「Param內容」範例(param)：[{"Name":"test_A","Mobile":"+886900000001","Email":"testA@test.com.tw","SendTime":"29990109083000","Param":"測試A1A2"},{"Name":"test_B","Mobile":"+886900000002","Email":"testB@test.com.tw","SendTime":"29990125173000","Param":"測試B1B2"}]
                    postDataSb.Append("{\"UID\":\"").Append(userID).Append("\",");
                    postDataSb.Append("\"PWD\":\"").Append(password).Append("\",");
                    postDataSb.Append("\"SB\":\"").Append(subject).Append("\",");
                    postDataSb.Append("\"RecipientDataList\":").Append(param).Append("}");
                    resultString = httpPost(sendParamSMSUrl, postDataSb.ToString(), isPersonal);
                }
                #endregion

                #region MMS一般簡訊
                if (isMMS)
                {
                    postDataSb.Append("UID=").Append(userID);
                    postDataSb.Append("&PWD=").Append(password);
                    postDataSb.Append("&SB=").Append(subject);
                    postDataSb.Append("&MSG=").Append(content);
                    postDataSb.Append("&DEST=").Append(mobile);
                    postDataSb.Append("&ST=").Append(sendTime);
                    postDataSb.Append("&ATTACHMENT=").Append(attachment);
                    postDataSb.Append("&TYPE=").Append(type);
                    resultString = httpPost(sendMMSUrl, postDataSb.ToString(), false);
                }
                #endregion

                processMsg = resultString;

                #region SMS、MMS一般簡訊發送結果
                if (!isParam && !isPersonal && !resultString.StartsWith("-"))
                {
                    /* 
                     * 傳送成功 回傳字串內容格式為：CREDIT,SENDED,COST,UNSEND,BATCH_ID，各值中間以逗號分隔。
                     * CREDIT：發送後剩餘點數。負值代表發送失敗，系統無法處理該命令
                     * SENDED：發送通數。
                     * COST：本次發送扣除點數
                     * UNSEND：無額度時發送的通數，當該值大於0而剩餘點數等於0時表示有部份的簡訊因無額度而無法被發送。
                     * BATCH_ID：批次識別代碼。為一唯一識別碼，可藉由本識別碼查詢發送狀態。格式範例：220478cc-8506-49b2-93b7-2505f651c12e
                     */
                    split = resultString.Split(',');
                    credit = Convert.ToDouble(split[0]);
                    batchID = split[4];
                    return success = true;
                }
                #endregion

                #region SMS參數、個人化(專屬)簡訊發送結果
                if ((isParam || isPersonal) && resultString.Contains("true"))
                {
                    /* 
                     * 傳送成功 回傳字串內容格式為：{"Result":true,"Status":"0","Msg":"CREDIT,SENDED,COST,UNSEND,BATCH_ID"}
                     * CREDIT：發送後剩餘點數。負值代表發送失敗，系統無法處理該命令
                     * SENDED：發送通數。
                     * COST：本次發送扣除點數
                     * UNSEND：無額度時發送的通數，當該值大於0而剩餘點數等於0時表示有部份的簡訊因無額度而無法被發送。
                     * BATCH_ID：批次識別代碼。為一唯一識別碼，可藉由本識別碼查詢發送狀態。格式範例：220478cc-8506-49b2-93b7-2505f651c12e
                     */
                    int s = resultString.IndexOf("Msg") + 6;
                    int e = resultString.Length - 2;
                    split = resultString.Substring(s, e - s).Split(',');
                    credit = Convert.ToDouble(split[0]);
                    batchID = split[4];
                    return success = true;
                }
                #endregion

                //傳送失敗
                processMsg = resultString;

            }
            catch (Exception ex)
            {
                processMsg = ex.ToString();
            }
            return success;
        }

        /// <summary>
        /// 取得帳號餘額
        /// </summary>
        /// <returns>true:取得成功；false:取得失敗</returns>
        public bool getCredit(string userID, string password)
        {
            bool success = false;
            try
            {
                StringBuilder postDataSb = new StringBuilder();
                postDataSb.Append("UID=").Append(userID);
                postDataSb.Append("&PWD=").Append(password);

                string resultString = httpPost(getCreditUrl, postDataSb.ToString(), false);
                if (!resultString.StartsWith("-"))
                {
                    credit = Convert.ToDouble(resultString);
                    success = true;
                }
                else
                {
                    processMsg = resultString;
                }
            }
            catch (Exception ex)
            {
                processMsg = ex.ToString();
            }
            return success;
        }

        private string httpPost(string url, string postData, bool isSendParamSMS)
        {
            string result = "";
            try
            {

                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(new Uri(url));
                request.Method = "POST";
                if (!isSendParamSMS)
                {
                    request.ContentType = "application/x-www-form-urlencoded";
                }
                else
                {
                    request.ContentType = "application/json";
                }
                byte[] bs = System.Text.Encoding.UTF8.GetBytes(postData);
                request.ContentLength = bs.Length;
                request.GetRequestStream().Write(bs, 0, bs.Length);
                //取得 WebResponse 的物件 然後把回傳的資料讀出
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                result = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                processMsg = ex.ToString();
            }
            return result;
        }

        public string ProcessMsg
        {
            get
            {
                return processMsg;
            }
        }

        public string BatchID
        {
            get
            {
                return batchID;
            }
        }

        public double Credit
        {
            get
            {
                return credit;
            }
        }
    }
}
