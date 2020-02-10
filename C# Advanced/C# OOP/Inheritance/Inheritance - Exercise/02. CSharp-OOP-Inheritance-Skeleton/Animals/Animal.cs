namespace Animals
{
    public class Animal
    {
        //•	Each Animal should have a name, an age and a gender


        public string name;
        public int age;
        public string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
