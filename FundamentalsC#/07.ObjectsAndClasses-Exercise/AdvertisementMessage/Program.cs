using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phrases = new List<string>()
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            List<string> events = new List<string>()
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            List<string> authors = new List<string>()
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };
            List<string> cities = new List<string>()
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"

            };

            int fakeAdds = int.Parse(Console.ReadLine());

            List<string> ads = new List<string>(fakeAdds);

            for (int i = 0; i < fakeAdds; i++)
            {
                List<string> currentAdd = new List<string>(4);


                Random random = new Random();
                int phrasesIndex = random.Next(0, phrases.Count);
                currentAdd.Add(phrases[phrasesIndex]);

                int eventsIndex = random.Next(0, events.Count);
                currentAdd.Add(events[eventsIndex]);

                int authorsIndex = random.Next(0, authors.Count);
                currentAdd.Add(authors[authorsIndex]);

                int citiesIndex = random.Next(0, cities.Count);
                currentAdd.Add($" {cities[citiesIndex]}");

                string addToList = string.Join(" ", currentAdd);
                ads.Add(addToList);
            }

            foreach (string ad in ads)
            {
                Console.WriteLine(ad);
            }
        }
    }
}
