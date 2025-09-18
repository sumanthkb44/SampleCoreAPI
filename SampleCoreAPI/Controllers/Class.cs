using System;

namespace SampleCoreAPI.Controllers
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public string GetProductDetails()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price:C}";
        }
    }
}
