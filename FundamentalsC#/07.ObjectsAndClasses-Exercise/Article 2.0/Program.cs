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
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<Article> articleStorage = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                List<string> article = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

                Article newArticle = new Article(article[0], article[1], article[2]);

                articleStorage.Add(newArticle);
            }

            string whatever = Console.ReadLine();

            foreach (Article article in articleStorage)
            {
                Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
            }
        }
    }
}
