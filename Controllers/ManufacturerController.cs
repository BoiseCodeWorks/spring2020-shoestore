using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shoestoore.Models;
using shoestoore.Services;

namespace shoestoore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturersController : ControllerBase
    {
        private readonly ManufacturersService _ms;
        private readonly ShoesService _ss;
        public ManufacturersController(ManufacturersService ms, ShoesService ss)
        {
            _ms = ms;
            _ss = ss;
        }

        // get all
        [HttpGet]
        public ActionResult<IEnumerable<Manufacturer>> Get()
        {
            try
            {
                return Ok(_ms.Get());
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
        public ActionResult<Manufacturer> Get(int id)
        {
            try
            {
                return Ok(_ms.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/shoes")]  // api/manufactuer/:id/shoes
        public ActionResult<IEnumerable<Shoe>> GetShoesByMfgId(int id)
        {
            try
            {
                return Ok(_ss.GetShoesByMfgId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // create 
        [HttpPost]
        public ActionResult<Manufacturer> Create([FromBody] Manufacturer newManufacturer)
        {
            try
            {
                return Ok(_ms.Create(newManufacturer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // update
        [HttpPut("{id}")]
        public ActionResult<Manufacturer> Update(int id, [FromBody] Manufacturer updatedManufacturer)
        {
            try
            {
                updatedManufacturer.Id = id;
                return Ok(_ms.Edit(updatedManufacturer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // delete
        [HttpDelete("{id}")]
        public ActionResult<Manufacturer> Delete(int id)
        {
            try
            {
                return Ok(_ms.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
