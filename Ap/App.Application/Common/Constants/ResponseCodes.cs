#pragma warning disable CS1591

#region

using App.Application.Common.Dtos;

#endregion

namespace App.Application.Common.Constants
{
    public static class ResponseCodes
    {
        #region common

        public static ErrorCode ValidationError { get; } = new ErrorCode("V0001", "資料格式錯誤");

        public static ErrorCode AlreadyExistsError { get; } = new ErrorCode("V0001", "資源已存在");

        public static ErrorCode NotFoundError { get; } = new ErrorCode("N0001", "資源不存在");

        public static ErrorCode GeneralBusinessError { get; } = new ErrorCode("B0001", "");

        public static ErrorCode DbCreateFailed { get; } = new ErrorCode("D0001", "資料建立失敗");

        public static ErrorCode DbUpdateFailed { get; } = new ErrorCode("D0002", "資料更新失敗");

        public static ErrorCode DbRemoveFailed { get; } = new ErrorCode("D0003", "資料移除失敗");

        public static ErrorCode InvalidSortProperty { get; } = new ErrorCode("Q0001", "無效資料查詢排序欄位");

        #endregion

        #region auth

        public static ErrorCode ApiUnAuthorized { get; } = new ErrorCode("UA001", "api unAuthorized", 401);

        public static ErrorCode IllegalJwtToken { get; } = new ErrorCode("UA002", "illegal jwt token", 401);

        public static ErrorCode IdentityUnAuthorized { get; } = new ErrorCode("UA002", "user unAuthorized", 401);

        public static ErrorCode PrivilegeUnAuthorized { get; } = new ErrorCode("UA003", "privilege unAuthorized", 401);

        public static ErrorCode SsoUnAuthorized { get; } = new ErrorCode("UA004", "SSO unAuthorized", 401);

        public static ErrorCode DataUnAuthorized { get; } = new ErrorCode("UA005", "Data privilege unAuthorized", 401);

        #endregion


        #region exceptions

        public static ErrorCode UnexpectedError { get; } = new ErrorCode("E0001", "未預期錯誤，請稍候再試。", 500);

        public static ErrorCode ExternalServiceError { get; } = new ErrorCode("W0001", "外部 API 錯誤, 請稍候再試。", 500);

        #endregion
    }
}
