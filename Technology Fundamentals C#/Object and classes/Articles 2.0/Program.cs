using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Articles> allArticles = new List<Articles>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] articlesAsArray = Console.ReadLine().Split(", ").ToArray();
                Articles articles = new Articles(articlesAsArray[0], articlesAsArray[1], articlesAsArray[2]);
                allArticles.Add(articles);
            }
            string order = Console.ReadLine();
            if (order == "title")
            {

                allArticles = allArticles.OrderBy(x => x.Title).ToList();
            }
            else if (order == "content")
            {
               allArticles = allArticles.OrderBy(x => x.Content).ToList();
            }
            else if (order == "author")
            {
                allArticles = allArticles.OrderBy(x => x.Author).ToList();
            }

            for (int i = 0; i < allArticles.Count; i++)
            {
                Console.WriteLine(allArticles[i].ToString());
            }
        }

    }
    class Articles
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Articles(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }


        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
