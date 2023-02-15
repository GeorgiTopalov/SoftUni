using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        class Product
        {
            public Product(double price, int quantity)
            {
                this.Price = price;
                this.Quantity = quantity;
            }
            public double Price { get; set; }
            public int Quantity { get; set; }

        }
        static void Main(string[] args)
        {
            string input = String.Empty;

            Dictionary<string, Product> products = new Dictionary<string, Product>();

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] productArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string productName = productArgs[0];
                double price = double.Parse(productArgs[1]);
                int quantity = int.Parse(productArgs[2]);

                Product product = new Product(price, quantity);

                if (!products.ContainsKey(productName))
                {
                    products.Add(productName, product);
                }
                else
                {
                    products[productName].Price = price;
                    products[productName].Quantity += quantity;
                }
            }   

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {product.Value.Price * product.Value.Quantity:f2}");
            }
        }
    }
}
