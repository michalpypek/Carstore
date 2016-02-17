using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IBaseService<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T GetById(Int32 id);
        void Add(T domainObject);
        void Update(T domainObject);
        void Delete(T domainObject);
        void Delete(int domainObjectId);
        void Commit();
        Task CommitAsync();
    }
}