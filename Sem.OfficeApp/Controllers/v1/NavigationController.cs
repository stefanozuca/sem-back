using Microsoft.AspNetCore.Mvc;
using Sem.Application.Features.NavigationFeatures.Queries;
using System.Threading.Tasks;

namespace Sem.OfficeApp.Controllers.v1
{
    [ApiVersion("1.0")]
    public class NavigationController : BaseApiController
    {
        /// <summary>
        /// Gets all Navigations.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllNavigationsQuery()));
        }
    }
}
