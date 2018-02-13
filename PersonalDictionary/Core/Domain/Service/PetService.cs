using PersonalDictionary.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalDictionary.Core.Domain.Service
{
    public class PetService : Repository<Pet>, IPetRepository
    {
        public List<Pet> SortPets(
                List<Pet> list,
                    CompareOptions opt,
                    SortOrder ord)
        {
            return list.OrderBy(p => p.Name).ToList();


            //list.ToList().Sort((x, y) =>
            //{

            //    switch (opt)
            //    {
            //        case CompareOptions.ByPetName:
            //            comp = x.Name.CompareTo(y.Name);
            //            break;
            //        default: throw new Exception();
            //    }
            //    if (ord == SortOrder.Descending)
            //    {
            //        comp = -comp;
            //    }
            //    return comp;
            //});

        }
    }
}