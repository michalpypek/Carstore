using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public abstract class BaseService<T> : IBaseService<T>
    {
        protected IDataFacade _dataSource;

        public BaseService(IDataFacade dataSource)
        {
            _dataSource = dataSource;
        }

        public BaseService()
        {
            _dataSource = new DataFacade(new DAL.ApplicationDbContext());
        }

        public abstract void Add(T domainObject);

        public void Commit()
        {
            _dataSource.Commit();
        }

        public Task CommitAsync()
        {
            return _dataSource.CommitAsync();
        }

        public abstract void Delete(int domainObjectId);

        public abstract void Delete(T domainObject);

        public abstract IEnumerable<T> GetAll();

        public abstract T GetById(int id);

        public abstract void Update(T domainObject);

        public void Dispose()
        {
            _dataSource.Dispose();
        }
    }
}
