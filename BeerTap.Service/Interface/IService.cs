using System;
using System.Collections.Generic;

namespace BeerTap.Service.Interface
{
    public interface IService<T>
    {
        void Insert(T domainModel);
        void Update(T domainModel);
        void Delete(Guid id);
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}
