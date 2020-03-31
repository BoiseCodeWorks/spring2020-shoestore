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
            (name, price, size, mfgId)
            VALUES
            (@Name, @Price, @Size, @MfgId);
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
                size = @Size,
                mfgId = @MfgId
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

        internal IEnumerable<Shoe> GetShoesByMfgId(int Id)
        {
            string sql = "SELECT * FROM shoes WHERE mfgId = @Id";
            return _db.Query<Shoe>(sql, new { Id });
        }

        internal IEnumerable<Shoe> GetShoesByCartId(int Id)
        {
            string sql = @"
            SELECT s.* FROM cartshoes cs
            INNER JOIN shoes s ON s.id = cs.shoeId
            WHERE cartId = @Id;";
            return _db.Query<Shoe>(sql, new { Id });
        }
    }
}