using System;
using System.Collections.Generic;
using shoestoore.Models;
using shoestoore.Repositories;

namespace shoestoore.Services
{
    public class ShoesService
    {
        private readonly ShoesRepository _repo;
        public ShoesService(ShoesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Shoe> Get()
        {
            return _repo.Get();
        }

        internal Shoe Get(int id)
        {
            Shoe found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Shoe Create(Shoe newShoe)
        {
            Shoe created = _repo.Create(newShoe);
            if (created == null)
            {
                throw new Exception("Create Request Failed");
            }
            return created;
        }

        internal Shoe Edit(Shoe updatedShoe)
        {
            Shoe original = Get(updatedShoe.Id);
            original.Name = updatedShoe.Name;
            original.Price = updatedShoe.Price != 0 ? updatedShoe.Price : original.Price;
            original.Size = updatedShoe.Size != 0 ? updatedShoe.Size : original.Size;
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