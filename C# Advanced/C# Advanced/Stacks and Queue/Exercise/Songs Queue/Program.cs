using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();

            Queue<string> songs = new Queue<string>(input);

            while (songs.Count> 0)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                switch (command[0])
                {
                    case "Add":
                        string songName = String.Join(" ",command);
                        songName = songName.Substring(4, songName.Length - 4);
                        if (!songs.Contains(songName))
                        {
                            songs.Enqueue(songName);
                        }
                        else
                        {
                            Console.WriteLine($"{songName} is already contained!");
                        }
                        break;
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ",songs));
                        break;                                                
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
