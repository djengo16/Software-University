using System;
using System.Collections.Generic;
using System.Linq;
namespace _7.Tuple
{
    class Startup
    {
        static void Main(string[] args)
        {
            //Adam Smith -> California
            //Mark-> 2
            //23-> 21.23212321

            var inputPersonInfo = Console.ReadLine().
                Split();

            var inputBeerInfo = Console.ReadLine().
                Split();

            var inputNumbersInfo = Console.ReadLine().
                Split();

            string personName = inputPersonInfo[0] + " " + inputPersonInfo[1];
            string personDomicile = inputPersonInfo[2];
            string personCity = string.Join(" ", inputPersonInfo.Skip(3));

            string beerPersonName = inputBeerInfo[0];
            int literOfBeer = int.Parse(inputBeerInfo[1]);
            string personCondition = inputBeerInfo[2];

            bool isDrunk = false;

            if (personCondition == "drunk")
            {
                isDrunk = true;
            }

            string clientName = inputNumbersInfo[0];
            double doubleNumber = double.Parse(inputNumbersInfo[1]);
            string bankName = inputNumbersInfo[2];

            var personInfo = new Threeuple<string, string,string>(personName,personDomicile,personCity);
            var personBeer = new Threeuple<string, int,bool>(beerPersonName, literOfBeer,isDrunk);
            var numbersInfo = new Threeuple<string, double,string>(clientName, doubleNumber,bankName);

            Console.WriteLine(personInfo);
            Console.WriteLine(personBeer);
            Console.WriteLine(numbersInfo);

        }
    }
}
