using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using DAL.Interface;


namespace Project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDo _dbStoreToDo;
        public ToDoController(IToDo dbStoreToDo)
        {
            _dbStoreToDo = dbStoreToDo;
        }
        // GET: api/<ToDosController>
        [HttpGet]
        public async Task<ActionResult<List<ToDo>>> GetToDos()
        {
            var res = await _dbStoreToDo.GetToDos();
            if (res.Count == 0)
                return BadRequest();
           // return Ok();
            return res;
        }

        //// POST api/<ToDosController>
        [HttpPost]
        public async Task<ActionResult<bool>> PostToDos([FromBody] ToDo toDo)
        {
            bool res = await _dbStoreToDo.PostToDos(toDo);
            if (!res)
                return BadRequest();
            return Ok();
        }
        [HttpPut]
        //// PUT api/<ToDosController>/5
        public async Task<ActionResult<bool>> PutToDos(ToDo todo)
        {
            bool res = await _dbStoreToDo.PutToDos(todo);
            if (!res)
                return BadRequest();
            return Ok();
        }

        [HttpDelete]
        [Route("api/DeleteToDos/{id}")]

        ////// DELETE api/<ToDosController>/5
        public async Task<ActionResult<bool>> DeleteToDos(int id)
        {
            bool res = await _dbStoreToDo.DeleteToDos(id);
            if (!res)
                return BadRequest();
            return Ok();
        }
    }
}

