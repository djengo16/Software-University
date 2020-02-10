using System;
using System.Collections.Generic;
using System.Linq;
namespace Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('\\').ToArray();
            string last = input[input.Length - 1];
            string[] lastSplitted = last.Split(".").ToArray();
            string fileName = lastSplitted[0];
            string fileExtension = lastSplitted[1];
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
            

        }
        
    }
}
