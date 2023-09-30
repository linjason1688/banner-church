using App.Api.AppScope.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Apis.Features
{
    [Route("api/[controller]")]
    
    [Auth]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ContentResult Index() 
        {
            return new ContentResult 
            {
                ContentType = "text/html",
                Content = "<div>Hello World</div>"
            };
        }
    }
}
