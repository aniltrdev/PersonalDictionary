using System.Collections.Generic;

namespace PersonalDictionary.Core.Domain
{
    public class Person 
    {
        public Person()
        {
            Pets = new List<Pet>();
        }

        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }
    }
}