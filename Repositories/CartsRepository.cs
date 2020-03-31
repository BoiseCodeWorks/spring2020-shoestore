using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using shoestoore.Models;

namespace shoestoore.Repositories
{
    public class CartsRepository
    {
        private readonly IDbConnection _db;
        public CartsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Cart> Get()
        {
            string sql = "SELECT * FROM carts";
            // NOTE essentially Find() returns array of results
            return _db.Query<Cart>(sql);
        }

        internal Cart Get(int Id)
        {
            string sql = "SELECT * FROM carts WHERE id = @Id";
            // NOTE essentialy FindOne() returns a single object or null
            return _db.QueryFirstOrDefault<Cart>(sql, new { Id });
        }

        internal Cart Create(Cart newCart)
        {
            string sql = @"
            INSERT INTO carts
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
            newCart.Id = _db.ExecuteScalar<int>(sql, newCart);
            return newCart;
        }
        internal void Edit(Cart updated)
        {
            string sql = @"
            UPDATE carts
            SET
                name = @Name
            WHERE id = @Id;
            ";
            _db.Execute(sql, updated);
        }

        internal bool Delete(int Id)
        {
            string sql = "DELETE FROM carts WHERE id = @Id LIMIT 1";
            int deleted = _db.Execute(sql, new { Id });
            return deleted == 1;
        }


    }
}