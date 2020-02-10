using System;

namespace Password_validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if(CheckIfContainsTwoDigits(password) && CheckIfDigitOrLetter(password) && CheckPasswordCharacters(password))
            {
                Console.WriteLine("Password is valid");
            }
            if (!CheckPasswordCharacters(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters ");
            }
            if (!CheckIfDigitOrLetter(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!CheckIfContainsTwoDigits(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

        }

        static bool CheckPasswordCharacters(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckIfDigitOrLetter(string password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                
                if (!char.IsLetterOrDigit(password[i]))
                {
                    return false;
                }                          
            }
            return true;
        }
        static bool CheckIfContainsTwoDigits(string password)
        {
            int digitCounter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    digitCounter++;
                }
            }
            if (digitCounter >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
