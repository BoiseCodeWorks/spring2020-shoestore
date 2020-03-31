using System;
using System.Collections.Generic;
using shoestoore.Models;
using shoestoore.Repositories;

namespace shoestoore.Services
{
    public class CartsService
    {
        private readonly CartsRepository _repo;
        public CartsService(CartsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Cart> Get()
        {
            return _repo.Get();
        }

        internal Cart Get(int id)
        {
            Cart found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Cart Create(Cart newCart)
        {
            Cart created = _repo.Create(newCart);
            if (created == null)
            {
                throw new Exception("Create Request Failed");
            }
            return created;
        }

        internal Cart Edit(Cart updatedCart)
        {
            Cart original = Get(updatedCart.Id);
            original.Name = updatedCart.Name;
            _repo.Edit(original);
            return original;
        }

        internal String Delete(int id)
        {
            if (_repo.Delete(id))
            {
                return "Successfully Deleted";
            }
            throw new Exception("Invalid Id");
        }
    }
}