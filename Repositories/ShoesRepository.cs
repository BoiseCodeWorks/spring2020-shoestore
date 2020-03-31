using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using shoestoore.Models;

namespace shoestoore.Repositories
{
    public class ShoesRepository
    {
        private readonly IDbConnection _db;
        public ShoesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Shoe> Get()
        {
            string sql = "SELECT * FROM shoes";
            // NOTE essentially Find() returns array of results
            return _db.Query<Shoe>(sql);
        }

        internal Shoe Get(int Id)
        {
            string sql = "SELECT * FROM shoes WHERE id = @Id";
            // NOTE essentialy FindOne() returns a single object or null
            return _db.QueryFirstOrDefault<Shoe>(sql, new { Id });
        }

        internal Shoe Create(Shoe newShoe)
        {
            string sql = @"
            INSERT INTO shoes
            (name, price, size)
            VALUES
            (@Name, @Price, @Size);
            SELECT LAST_INSERT_ID();
            ";
            newShoe.Id = _db.ExecuteScalar<int>(sql, newShoe);
            return newShoe;
        }
        internal void Edit(Shoe updated)
        {
            string sql = @"
            UPDATE shoes
            SET
                name = @Name,
                price = @Price,
                size = @Size
            WHERE id = @Id;
            ";
            _db.Execute(sql, updated);
        }

        internal bool Delete(int Id)
        {
            string sql = "DELETE FROM shoes WHERE id = @Id LIMIT 1";
            int deleted = _db.Execute(sql, new { Id });
            return deleted == 1;
        }


    }
}