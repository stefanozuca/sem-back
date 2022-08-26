using Microsoft.AspNetCore.Mvc;
using Sem.Application.Features.BlogFeatures.Command;
using Sem.Application.Features.BlogFeatures.Queries;
using System.Threading.Tasks;

namespace Sem.OfficeApp.Controllers.v1
{

    [ApiVersion("1.0")]
    public class BlogController : BaseApiController
    {
        /// <summary>
        /// Gets all Blogs.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllBlogQuery()));
        }

        /// <summary>
        /// Gets all Blogs Favs.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Favs")]
        public async Task<IActionResult> GetAllFavs()
        {
            return Ok(await Mediator.Send(new GetAllBlogFavsQuery()));
        }

        /// <summary>
        /// Creates a New Blog.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
