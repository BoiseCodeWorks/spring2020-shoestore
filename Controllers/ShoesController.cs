using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shoestoore.Models;
using shoestoore.Services;

namespace shoestoore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoesController : ControllerBase
    {
        private readonly ShoesService _ss;
        public ShoesController(ShoesService ss)
        {
            _ss = ss;
        }

        // get all
        [HttpGet]
        public ActionResult<IEnumerable<Shoe>> Get()
        {
            try
            {
                return Ok(_ss.Get());
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // get by id
        [HttpGet("{id}")]
        public ActionResult<Shoe> Get(int id)
        {
            try
            {
                return Ok(_ss.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // create 
        [HttpPost]
        public ActionResult<Shoe> Create([FromBody] Shoe newShoe)
        {
            try
            {
                return Ok(_ss.Create(newShoe));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // update
        [HttpPut("{id}")]
        public ActionResult<Shoe> Update(int id, [FromBody] Shoe updatedShoe)
        {
            try
            {
                updatedShoe.Id = id;
                return Ok(_ss.Edit(updatedShoe));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // delete
        [HttpDelete("{id}")]
        public ActionResult<Shoe> Delete(int id)
        {
            try
            {
                return Ok(_ss.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
