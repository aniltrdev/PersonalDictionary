using PersonalDictionary.Core.Domain;
using PersonalDictionary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalDictionary.Core.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<List<PersonViewModel>> GetAllPetsGroupedByOwnersGender();
        T DeserializeResults<T>(string result);
    }
}