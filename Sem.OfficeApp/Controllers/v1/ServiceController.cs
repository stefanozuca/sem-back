using Microsoft.AspNetCore.Mvc;
using Sem.Application.Features.ServicesFeatures.Command;
using Sem.Application.Features.ServicesFeatures.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sem.OfficeApp.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ServiceController : BaseApiController
    {
        /// <summary>
        /// Gets all services.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllServicesQuery()));
        }

        /// <summary>
        /// Creates a New Blog.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
