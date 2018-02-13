using PersonalDictionary.Core.Domain;
using System.Collections.Generic;

namespace PersonalDictionary.Models
{
    public class PersonViewModel
    {
        public string Gender { get; set; }
        public IList<Pet> Pets { get; set; }
    }
}