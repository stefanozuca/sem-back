
using Microsoft.AspNetCore.Mvc;
using Sem.Application.Features.TopicFeatures.Command;
using Sem.Application.Features.TopicFeatures.Queries;
using System.Threading.Tasks;

namespace Sem.OfficeApp.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TopicController : BaseApiController
    {
        /// <summary>
        /// Gets all Topics.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTopicQuery()));
        }

        /// <summary>
        /// Creates a New Topic.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateTopicCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
