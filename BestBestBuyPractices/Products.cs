﻿using System;
namespace BestBestBuyPractices
{
    public class Products
    {
        public Products()
        {
        }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public string StockLevel { get; set; }
    }
}
