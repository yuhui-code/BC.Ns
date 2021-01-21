using BC.Ns.Domain.Interface;
using System.Threading.Tasks;
using System.Web.Http;

namespace BC.Ns.Api.Controllers
{
    /// <summary>
    /// Canary Controller
    /// </summary>
    [RoutePrefix("api/canary")]
    public class CanaryController : ApiController
    {
        private readonly ICanaryDomain _canaryDomain;

        /// <summary>
        /// Canary Controller
        /// </summary>
        /// <param name="canaryDomain"></param>
        public CanaryController(ICanaryDomain canaryDomain)
        {
            _canaryDomain = canaryDomain;
        }

        /// <summary>
        /// Get Test
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("healthmonitor")]
        [AllowAnonymous]
        public async Task<bool> GetTest()
        {
            return await _canaryDomain.GetTest();
        }
    }
}