using Microsoft.AspNetCore.Mvc;
using Sem.Application.Features.WorkItemFeatures.Commands;
using Sem.Application.Features.WorkItemFeatures.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sem.OfficeApp.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WorkItemController : BaseApiController
    {
        /// <summary>
        /// Creates a New WorkItem.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all WorkItems.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllWorkItemsQuery()));
        }
        /// <summary>
        /// Gets WorkItem Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetWorkItemByIdQuery { WorkItemId = id }));
        }
        /// <summary>
        /// Deletes WorkItem Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteWorkItemByIdCommand { WorkItemId = id }));
        }
        /// <summary>
        /// Updates the WorkItem Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateWorkItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
