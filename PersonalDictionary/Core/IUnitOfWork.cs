using PersonalDictionary.Core.Repositories;
using System;

namespace PersonalDictionary.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Persons { get; }
        IPetRepository Pets { get; }
        int Complete();
    }
}