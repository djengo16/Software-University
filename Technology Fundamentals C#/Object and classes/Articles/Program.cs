using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articlesAsArray = Console.ReadLine().Split(", ").ToArray();

            Articles articles = new Articles(articlesAsArray[0],articlesAsArray[1],articlesAsArray[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ").ToArray();

                switch (command[0])
                {
                    case "Edit":
                        articles.Edit(command[1]);
                            break;
                    case "ChangeAuthor":
                        articles.ChangeAuthor(command[1]);
                            break;
                    case "Rename":
                        articles.Rename(command[1]);
                        break;
                }

            }
            Console.WriteLine(articles.ToString());
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
        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
