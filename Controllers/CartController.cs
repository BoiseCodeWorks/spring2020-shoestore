using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shoestoore.Models;
using shoestoore.Services;

namespace shoestoore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly CartsService _cs;
        public CartsController(CartsService cs)
        {
            _cs = cs;
        }

        // get all
        [HttpGet]
        public ActionResult<IEnumerable<Cart>> Get()
        {
            try
            {
                return Ok(_cs.Get());
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
        public ActionResult<Cart> Get(int id)
        {
            try
            {
                return Ok(_cs.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // create 
        [HttpPost]
        public ActionResult<Cart> Create([FromBody] Cart newCart)
        {
            try
            {
                return Ok(_cs.Create(newCart));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // update
        [HttpPut("{id}")]
        public ActionResult<Cart> Update(int id, [FromBody] Cart updatedCart)
        {
            try
            {
                updatedCart.Id = id;
                return Ok(_cs.Edit(updatedCart));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // delete
        [HttpDelete("{id}")]
        public ActionResult<Cart> Delete(int id)
        {
            try
            {
                return Ok(_cs.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
