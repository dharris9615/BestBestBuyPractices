using System;
using System.Collections.Generic;

namespace BestBestBuyPractices
{
    public interface IProductsRepository
    {
        IEnumerable<Products> GetAllProducts();

        void CreateProduct(string name, double price, int categoryID);

    }
}
