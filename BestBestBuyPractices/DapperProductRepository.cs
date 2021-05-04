using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace BestBestBuyPractices
{
    public class DapperProductRepository : IProductsRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) values (@NAme, @Price, @CategoryID);",
                new {name = name, price = price, categoryID = categoryID});
        }

        public IEnumerable<Products> GetAllProducts()
        {
           return  _connection.Query<Products>("SELECT * FROM PRODUCTS;");
        }

        public void UpdateProduct(int productID, string updateName)
        {
            _connection.Execute("UPDATE products SET Name = @updateName WHERE ProductID = @productID;",
                new { updateName = updateName, productID = productID } );
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE productID = @ProductID;",
                new { productID = productID });

            _connection.Execute("DELETE FROM sales WHERE productID = @ProductID;",
                new { productID = productID });

            _connection.Execute("DELETE FROM products WHERE productID = @ProductID;",
                new { productID = productID });
        }
    }
}
