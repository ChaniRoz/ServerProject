using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using DAL.Interface;


namespace Project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _dbStoreUsers;
        public UsersController(IUsers dbStoreUsers)
        {
            _dbStoreUsers = dbStoreUsers;
        }
        // GET: api/<UserssController>
        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetUsers()
        {
            var res = await _dbStoreUsers.GetUsers();
            if (res.Count == 0)
                return BadRequest();
           // return Ok();
            return res;
        }

        //// POST api/<UserssController>
        [HttpPost]
        public async Task<ActionResult<bool>> PostUsers([FromBody] Users Users)
        {
            bool res = await _dbStoreUsers.PostUsers(Users);
            if (!res)
                return BadRequest();
            return Ok();
        }
        [HttpPut]
        //// PUT api/<UserssController>/5
        public async Task<ActionResult<bool>> PutUsers(Users Users)
        {
            bool res = await _dbStoreUsers.PutUsers(Users);
            if (!res)
                return BadRequest();
            return Ok();
        }

        [HttpDelete]
        [Route("api/DeleteUserss/{id}")]

        ////// DELETE api/<UserssController>/5
        public async Task<ActionResult<bool>> DeleteUsers(int id)
        {
            bool res = await _dbStoreUsers.DeleteUsers(id);
            if (!res)
                return BadRequest();
            return Ok();
        }
    }
}

