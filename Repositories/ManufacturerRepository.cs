using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using shoestoore.Models;

namespace shoestoore.Repositories
{
    public class ManufacturersRepository
    {
        private readonly IDbConnection _db;
        public ManufacturersRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Manufacturer> Get()
        {
            string sql = "SELECT * FROM manufacturers";
            // NOTE essentially Find() returns array of results
            return _db.Query<Manufacturer>(sql);
        }

        internal Manufacturer Get(int Id)
        {
            string sql = "SELECT * FROM manufacturers WHERE id = @Id";
            // NOTE essentialy FindOne() returns a single object or null
            return _db.QueryFirstOrDefault<Manufacturer>(sql, new { Id });
        }

        internal Manufacturer Create(Manufacturer newManufacturer)
        {
            string sql = @"
            INSERT INTO manufacturers
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
            newManufacturer.Id = _db.ExecuteScalar<int>(sql, newManufacturer);
            return newManufacturer;
        }
        internal void Edit(Manufacturer updated)
        {
            string sql = @"
            UPDATE manufacturers
            SET
                name = @Name
            WHERE id = @Id;
            ";
            _db.Execute(sql, updated);
        }

        internal bool Delete(int Id)
        {
            string sql = "DELETE FROM manufacturers WHERE id = @Id LIMIT 1";
            int deleted = _db.Execute(sql, new { Id });
            return deleted == 1;
        }


    }
}