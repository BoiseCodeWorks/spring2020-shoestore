using System;
using System.Collections.Generic;
using shoestoore.Models;
using shoestoore.Repositories;

namespace shoestoore.Services
{
    public class CartShoesService
    {
        private readonly CartShoesRepository _repo;
        public CartShoesService(CartShoesRepository repo)
        {
            _repo = repo;
        }

        // internal CartShoes Get(int id)
        // {
        //     CartShoes found = _repo.Get(id);
        //     if (found == null)
        //     {
        //         throw new Exception("Invalid Id");
        //     }
        //     return found;
        // }

        internal CartShoes Create(CartShoes newCartShoes)
        {
            CartShoes created = _repo.Create(newCartShoes);
            if (created == null)
            {
                throw new Exception("Create Request Failed");
            }
            return created;
        }
        internal String Delete(CartShoes cs)
        {
            if (_repo.Delete(cs))
            {
                return "Successfully Deleted";
            }
            throw new Exception("Invalid Id");
        }
    }
}