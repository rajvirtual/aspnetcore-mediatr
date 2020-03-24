using Blip.Core.Commands;
using Blip.Core.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Blip.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : BaseController
    {
        public BlogController()
        {
        }

        [HttpGet("blogs")]
        public async Task<ActionResult> Get()
        {
            var result = await Mediator.Send(new GetBlogsQuery());
            return Ok(result);
        }

        [HttpPost("createblog")]
        public async Task<ActionResult<int>> Create(CreateBlogCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("updateblog")]
        public async Task<ActionResult<int>> Update(UpdateBlogCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("deleteblog")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteBlogCommand { Id = id });
            return NoContent();
        }
    }
}
