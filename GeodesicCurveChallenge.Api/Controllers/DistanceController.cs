using GeodesicCurveChallenge.Business.Managers.Interfaces;
using GeodesicCurveChallenge.Business.Models;
using GeodesicCurveChallenge.Infrastructure.Response;
using GeodesicCurveChallenge.Infrastructure.Web.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeodesicCurveChallenge.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class DistanceController : BaseApiController
    {
        private readonly IDistanceManager _distanceManager;

        public DistanceController(IDistanceManager distanceManager)
        {
            _distanceManager = distanceManager;
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public ActionResult<double> Calculate(GeodesicCurve model)
        {
            return ResponseResult(_distanceManager.Calculate(model).Ok());
        }
    }
}
