using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IDataFacade : IDisposable
    {
        void Commit();
        Task CommitAsync();
        CarRepository Cars { get; }
        SegmentRepository Segments { get; }
    }
}
