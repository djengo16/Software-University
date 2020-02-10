using System;

namespace _1._Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] words = new string[size];
            int[] finalResult = new int[size];
            int currentResult = 0;
            string currentName = string.Empty;
            char[] vowels = new[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            bool isVowel = true;
            for (int i = 0; i < size; i++)
            {
                words[i] = Console.ReadLine();
            }
            for (int i = 0; i < size; i++)
            {
                currentName = words[i];
                for (int j = 0; j < words[i].Length ; j++)
                {
                    for (int y = 0; y < vowels.Length; y++)
                    {
                        if (currentName[j] == vowels[y])
                        {
                            isVowel = false;
                        }                        
                    }                  
                    if (isVowel)
                    {
                        currentResult += (currentName[j] / currentName.Length);
                    }
                    else
                    {
                        currentResult += (currentName.Length * currentName[j]);
                    }
                    // currentResult += currentName[j];
                    isVowel = true;
                }
                finalResult[i] = currentResult;
                currentResult = 0;
            }
            Array.Sort(finalResult);           
            foreach (int i in finalResult) Console.WriteLine(i); 
        }
    }
}
