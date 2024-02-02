using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using DAL.Interface;


namespace Project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhoto _dbStorePhoto;
        public PhotoController(IPhoto dbStorePhoto)
        {
            _dbStorePhoto = dbStorePhoto;
        }
        // GET: api/<PhotosController>
        [HttpGet]
        public async Task<ActionResult<List<Photo>>> GetPhotos()
        {
            var res = await _dbStorePhoto.GetPhotos();
            if (res.Count == 0)
                return BadRequest();
           // return Ok();
            return res;
        }

        //// POST api/<PhotosController>
        [HttpPost]
        public async Task<ActionResult<bool>> PostPhotos([FromBody] Photo Photo)
        {
            bool res = await _dbStorePhoto.PostPhotos(Photo);
            if (!res)
                return BadRequest();
            return Ok();
        }
        [HttpPut]
        //// PUT api/<PhotosController>/5
        public async Task<ActionResult<bool>> PutPhotos(Photo Photo)
        {
            bool res = await _dbStorePhoto.PutPhotos(Photo);
            if (!res)
                return BadRequest();
            return Ok();
        }

        [HttpDelete]
        [Route("api/DeletePhotos/{id}")]

        ////// DELETE api/<PhotosController>/5
        public async Task<ActionResult<bool>> DeletePhotos(int id)
        {
            bool res = await _dbStorePhoto.DeletePhotos(id);
            if (!res)
                return BadRequest();
            return Ok();
        }
    }
}

