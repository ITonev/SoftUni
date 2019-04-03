using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles_2._0
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                var input = Console.ReadLine().Split(", ");

                Article article = new Article();
                article.Title = input[0];
                article.Content = input[1];
                article.Author = input[2];

                articles.Add(article);
            }

            string criteria = Console.ReadLine();
            switch (criteria)
            {
                case "title": articles = articles.OrderBy(x => x.Title).ToList();break;
                case "content": articles = articles.OrderBy(x => x.Content).ToList(); break;
                case "author": articles = articles.OrderBy(x => x.Author).ToList(); break;

            }
            foreach (var article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }
}
