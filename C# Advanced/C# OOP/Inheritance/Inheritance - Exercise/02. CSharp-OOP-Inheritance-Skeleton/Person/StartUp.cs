namespace Person
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person;

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age > 15)
            {
                person = new Person(name, age);                
            }
            else
            {
                person = new Child(name, age);
            }
            Console.WriteLine(person);
        }
    }
}