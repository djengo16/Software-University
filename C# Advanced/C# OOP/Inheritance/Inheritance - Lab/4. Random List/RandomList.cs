using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        Random rnd = new Random();

       public string RandomString(List<string> random)
        {
            string randomElement = random[rnd.Next(0, random.Count - 1)];
            random.Remove(randomElement);
                return randomElement;
        }
    }
}
