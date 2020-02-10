using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Dictionary<string, List<string>> bands = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandsPlaying = new Dictionary<string, int>();
            while ((command = Console.ReadLine()) != "start of concert")
            {
                string[] inputArr = command.Split("; ").ToArray();
                string bandName = inputArr[1];
                
               
                if (inputArr[0] == "Add")
                {
                    List<string> members = inputArr[2].Split(", ").ToList();
                    if (!bands.ContainsKey(bandName))
                    {
                        bands.Add(bandName, members);
                    }
                    else
                    {
                        foreach (var member in members )
                        {
                            if (!bands[bandName].Contains(member))
                            {
                                bands[bandName].Add(member);
                            }
                        }
                    }
                }
                else if (inputArr[0] == "Play")
                {
                    int time = int.Parse(inputArr[2]);
                    if (!bandsPlaying.ContainsKey(bandName))
                    {
                        bandsPlaying.Add(bandName, time);
                    }
                    else
                    {
                        bandsPlaying[bandName] += time;
                    }
                }
                bandsPlaying = bandsPlaying
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);
            }
            string bandToPrint = Console.ReadLine();

            Console.WriteLine($"Total time: {bandsPlaying.Values.Sum()}");
            foreach (var band in bandsPlaying)
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }
            Console.WriteLine(bandToPrint);
            foreach (var members in bands[bandToPrint])
            {
                Console.WriteLine($"=> {members}");
            }
        }
    }
}
