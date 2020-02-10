using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public void AddMember(Person person)
        {
            this.people.Add(person);
        }
        public Family()
        {
            this.people = new List<Person>();
        }

        public Person GetOldestMember()
              => people.OrderByDescending(p => p.Age).FirstOrDefault();

        public List<Person> Sort()
        {
          return this.people.Where(x=>x.Age > 30).OrderBy(x => x.Name).ToList();
        }
    }
}
