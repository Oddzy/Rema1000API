﻿namespace DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}