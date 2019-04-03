using System;
using System.Collections.Generic;

namespace Articles
{
    class Program
    {
        class Article
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public void Edit(string content)
            {
                this.Content = content;
            }

            public void ChangeAuthor(string author)
            {
                this.Author = author;
            }

            public void Rename(string title)
            {
                this.Title = title;
            }

            public override string ToString()
            {
                return $"{this.Title} - {this.Content}: {this.Author}";
            }

        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();
            Article article = new Article();
            article.Title = input[0];
            article.Content = input[1];
            article.Author = input[2];

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Edit": article.Edit(tokens[1]);break;
                    case "ChangeAuthor": article.ChangeAuthor(tokens[1]);break;
                    case "Rename":article.Rename(tokens[1]);break;
                    default:
                        break;
                }

            }

            Console.WriteLine(article);
        }
    }
}
