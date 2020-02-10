using System;
using System.Linq;
using System.Collections.Generic;

namespace Student_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Songs> allSongsInformation = new List<Songs>();

            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] current = Console.ReadLine().Split("_").ToArray();

                Songs songs = new Songs(current[0], current[1], current[2]);
                allSongsInformation.Add(songs);
            }
            string command = Console.ReadLine();

            if (command == "all")
            {
                for (int i = 0; i < allSongsInformation.Count; i++)
                {
                    Console.WriteLine(allSongsInformation[i].Name);
                }
            }
            else
            {
                for (int i = 0; i < allSongsInformation.Count; i++)
                {
                    if (command == allSongsInformation[i].TypeList)
                    {
                        Console.WriteLine(allSongsInformation[i].Name);
                    }
                }
            }
        }
    }
    class Songs
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        public Songs(string typeList, string name, string type)
        {
             TypeList = typeList;
             Name = name;
             Time = Time;
        }
    }
}
