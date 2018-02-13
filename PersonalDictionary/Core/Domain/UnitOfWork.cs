using PersonalDictionary.Core.Domain.Service;
using PersonalDictionary.Core.Repositories;
using System;

namespace PersonalDictionary.Core.Domain
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            Persons = new PersonService();
            Pets = new PetService();
        }

        public IPersonRepository Persons { get; private set; }
        public IPetRepository Pets { get; private set; }

        public int Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }
    }
}