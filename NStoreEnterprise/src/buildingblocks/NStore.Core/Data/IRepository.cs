using System;

namespace NStore.Core.DomainObjects
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {

    }
}
