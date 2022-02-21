using Microsoft.AspNetCore.Mvc;
using Sem.Application.Features.ContactFeatures.Queries;
using System.Threading.Tasks;

namespace Sem.OfficeApp.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ContactController : BaseApiController
    {
        /// <summary>
        /// Gets all Contacts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllContactQuery()));
        }
    }
}
