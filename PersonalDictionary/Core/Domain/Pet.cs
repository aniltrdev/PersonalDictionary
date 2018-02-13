using System;

namespace PersonalDictionary.Core.Domain
{
    public class Pet :IComparable<Pet>
    {
        public string Name { get; set; }
        public PetType Type { get; set; }

        public int CompareTo(Pet other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}