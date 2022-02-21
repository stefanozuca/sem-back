using Microsoft.AspNetCore.Mvc;
using Sem.Application.Features.HistoricalFeatures.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sem.OfficeApp.Controllers.v1
{
    [ApiVersion("1.0")]
    public class HistoricalCounterController : BaseApiController
    {
        /// <summary>
        /// Gets all Historical Counters.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllHistoricalCounterQuery()));
        }
    }
}
