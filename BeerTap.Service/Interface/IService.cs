using System;
using System.Collections.Generic;

namespace BeerTap.Service.Interface
{
    public interface IService<T>
    {
        int Insert(T domainModel);
        void Update(T domainModel);
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
