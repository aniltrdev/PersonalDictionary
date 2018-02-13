using PersonalDictionary.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalDictionary.Core.Repositories
{
    public interface IPetRepository : IRepository<Pet>
    {
        List<Pet> SortPets(List<Pet> list, CompareOptions opt, SortOrder ord);
    }
}