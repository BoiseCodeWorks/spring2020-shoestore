using System;
using System.Collections.Generic;
using shoestoore.Models;
using shoestoore.Repositories;

namespace shoestoore.Services
{
    public class ManufacturersService
    {
        private readonly ManufacturersRepository _repo;
        public ManufacturersService(ManufacturersRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Manufacturer> Get()
        {
            return _repo.Get();
        }

        internal Manufacturer Get(int id)
        {
            Manufacturer found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Manufacturer Create(Manufacturer newManufacturer)
        {
            Manufacturer created = _repo.Create(newManufacturer);
            if (created == null)
            {
                throw new Exception("Create Request Failed");
            }
            return created;
        }

        internal Manufacturer Edit(Manufacturer updatedManufacturer)
        {
            Manufacturer original = Get(updatedManufacturer.Id);
            original.Name = updatedManufacturer.Name;
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