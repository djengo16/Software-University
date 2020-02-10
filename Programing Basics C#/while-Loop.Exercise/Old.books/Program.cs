using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old.books
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchedBook = Console.ReadLine();
            int booksCount = int.Parse(Console.ReadLine());

            int counter = 0;
            while (counter < booksCount)
            {
                counter++;
                string nameOfBook = Console.ReadLine();
                if (nameOfBook == searchedBook)
                {
                    counter -= 1;
                    Console.WriteLine($"You checked {counter} books and found it.");
                    break;
                }
                if (nameOfBook != searchedBook && counter == booksCount)
                {                    
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;
                }                
            }            
        }
    }
}
