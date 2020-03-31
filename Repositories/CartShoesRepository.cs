using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using shoestoore.Models;

namespace shoestoore.Repositories
{
    public class CartShoesRepository
    {
        private readonly IDbConnection _db;
        public CartShoesRepository(IDbConnection db)
        {
            _db = db;
        }

        // internal CartShoes Get(int Id)
        // {
        //     string sql = "SELECT * FROM carts WHERE id = @Id";
        //     // NOTE essentialy FindOne() returns a single object or null
        //     return _db.QueryFirstOrDefault<CartShoes>(sql, new { Id });
        // }

        internal CartShoes Create(CartShoes newCartShoes)
        {
            string sql = @"
            INSERT INTO cartshoes
            (cartId, shoeId)
            VALUES
            (@CartId, @ShoeId);
            SELECT LAST_INSERT_ID();
            ";
            newCartShoes.Id = _db.ExecuteScalar<int>(sql, newCartShoes);
            return newCartShoes;
        }

        internal bool Delete(CartShoes cs)
        {
            string sql = "DELETE FROM cartshoes WHERE cartId = @CartId AND shoeId = @ShoeId LIMIT 1";
            int deleted = _db.Execute(sql, cs);
            return deleted == 1;
        }


    }
}