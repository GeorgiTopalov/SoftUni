using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine()
                .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine()
                .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Person> persons = new Dictionary<string, Person>();
            Dictionary<string, Product> allProducts = new Dictionary<string, Product>();

            try
            {
                for (int i = 0; i < people.Length; i += 2)
                {
                    string name = people[i];
                    decimal money = decimal.Parse(people[i + 1]);

                    Person person = new Person(name, money);
                    persons.Add(name, person);
                }

                for (int i = 0; i < products.Length; i += 2)
                {
                    string name = products[i];
                    decimal cost = decimal.Parse(products[i + 1]);
                    Product product = new Product(name, cost);
                    allProducts.Add(name, product);
                }

                string command = string.Empty;

                while ((command = Console.ReadLine()) != "END")
                {
                    string[] commandArgs = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string personName = commandArgs[0];
                    string productName = commandArgs[1];

                    Person person = persons[personName];
                    Product product = allProducts[productName];

                    bool canAfford = person.CanAffordProduct(product);

                    if (!canAfford)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }

                }
                foreach (var (name, person) in persons)
                {
                    string productsArgs = person.Products.Count > 0
                        ? string.Join(", ", person.Products.Select(x => x.Name))
                        : "Nothing bought";

                    Console.WriteLine($"{name} - {productsArgs}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
