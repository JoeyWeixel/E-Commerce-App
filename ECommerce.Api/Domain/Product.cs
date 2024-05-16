﻿namespace ECommerceAPI.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int numInStock { get; set; }
        public double Price { get; private set; }

    }
}