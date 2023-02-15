using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfChanges = int.Parse(Console.ReadLine());

            List<string> article = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Article newArticle = new Article(article[0], article[1], article[2]);

            

            for (int i = 0; i < numberOfChanges; i++)
            {
                List<string> input = Console.ReadLine().Split().ToList();
                string command = input[0];

                input.RemoveAt(0);

                string textToEdit = String.Join(' ', input);

                if (command == "Edit:")
                {
                   newArticle.Content  = textToEdit;
                }
                else if (command == "ChangeAuthor:")
                {
                    newArticle.Author = textToEdit;
                }
                else if (command == "Rename:")
                {
                    newArticle.Title = textToEdit;
                }
            }

            Console.WriteLine($"{newArticle.Title} - {newArticle.Content}: {newArticle.Author}");
        }
    }
}
