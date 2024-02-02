using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using DAL.Interface;


namespace Project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPost _dbStorePost;
        public PostController(IPost dbStorePost)
        {
            _dbStorePost = dbStorePost;
        }
        // GET: api/<PostsController>
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            var res = await _dbStorePost.GetPosts();
            if (res.Count == 0)
                return BadRequest();
           // return Ok();
            return res;
        }

        //// POST api/<PostsController>
        [HttpPost]
        public async Task<ActionResult<bool>> PostPosts([FromBody] Post Post)
        {
            bool res = await _dbStorePost.PostPosts(Post);
            if (!res)
                return BadRequest();
            return Ok();
        }
        [HttpPut]
        //// PUT api/<PostsController>/5
        public async Task<ActionResult<bool>> PutPosts(Post Post)
        {
            bool res = await _dbStorePost.PutPosts(Post);
            if (!res)
                return BadRequest();
            return Ok();
        }

        [HttpDelete]
        [Route("api/DeletePosts/{id}")]

        ////// DELETE api/<PostsController>/5
        public async Task<ActionResult<bool>> DeletePosts(int id)
        {
            bool res = await _dbStorePost.DeletePosts(id);
            if (!res)
                return BadRequest();
            return Ok();
        }
    }
}

