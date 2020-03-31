using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shoestoore.Models;
using shoestoore.Services;

namespace shoestoore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartShoesController : ControllerBase
    {
        private readonly CartShoesService _cs;
        public CartShoesController(CartShoesService cs)
        {
            _cs = cs;
        }

        // create 
        [HttpPost]
        public ActionResult<CartShoes> Create([FromBody] CartShoes newCartShoes)
        {
            try
            {
                return Ok(_cs.Create(newCartShoes));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // delete
        [HttpPut]  // api/cartshoes/:shoeCartId
        public ActionResult<CartShoes> Delete([FromBody] CartShoes toRemove)
        {
            try
            {
                return Ok(_cs.Delete(toRemove));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}



// update
// [HttpPut("{id}")]
// public ActionResult<CartShoes> Update(int id, [FromBody] CartShoes updatedCartShoes)
// {
//     try
//     {
//         updatedCartShoes.Id = id;
//         return Ok(_cs.Edit(updatedCartShoes));
//     }
//     catch (Exception e)
//     {
//         return BadRequest(e.Message);
//     }
// }


// get by id
// [HttpGet("{id}")]
// public ActionResult<CartShoes> Get(int id)
// {
//     try
//     {
//         return Ok(_cs.Get(id));
//     }
//     catch (Exception e)
//     {
//         return BadRequest(e.Message);
//     }
// }