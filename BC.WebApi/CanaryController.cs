using System.Threading.Tasks;
using System.Web.Mvc;

namespace BC.Ns.Api.Controllers
{
    public class CanaryController : Controller
    {
        public CanaryController()
        {
        }

        /// <summary>
        /// Get Test
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("healthmonitor")]
        [AllowAnonymous]
        public async Task<bool> GetTest()
        {
            return await Task.FromResult<bool>(true);
        }
    }
}