#region

using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;

#endregion

namespace App.Api.AppScope.Filters
{
    public class ApiModelValidGuard : IActionFilter, IOrderedFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var ms = context.ModelState;

            if (ms.IsValid)
            {
                return;
            }

            var invalidFields = string.Join(", ", ms.Keys);

            var invalidMsg = $"欄位資料型態不符! [ {invalidFields} ]";

#if DEBUG
            var vMsgList = ms.Values.Select(v => string.Join(",", v.Errors.Select(e => e.ErrorMessage)));

            var vErrMsg = string.Join(";", vMsgList);

            throw new ValidationException(
                $"{invalidMsg} \n {vErrMsg}"
            );
#else
            throw new ValidationException(invalidMsg);
#endif
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public int Order => 999;
    }
}
