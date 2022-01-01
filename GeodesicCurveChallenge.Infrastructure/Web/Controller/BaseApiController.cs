using GeodesicCurveChallenge.Infrastructure.Response;
using Microsoft.AspNetCore.Mvc;

namespace GeodesicCurveChallenge.Infrastructure.Web.Controller
{
    public class BaseApiController : ControllerBase
    {
        protected ObjectResult ResponseResult<T>(ResponseBase<T> responseBase)
        {
            if (responseBase.IsSuccess)
            {
                return Ok(responseBase.Result);
            }

            return BadRequest(responseBase.MessageList);
        }
    }
}
