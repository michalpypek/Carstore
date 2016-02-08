using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class DataFacade: IDataFacade
    {
        #region Fields
        private ApplicationDbContext _dbContext;
        private CarRepository _carRepository;
        private SegmentRepository _segmentRepository;
        #endregion

        #region Constructors
        public DataFacade(ApplicationDbContext dbContext)
        {
            CreateDbContext(dbContext);
        }

        protected void CreateDbContext(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? new ApplicationDbContext();

            _dbContext.Configuration.ProxyCreationEnabled = false;
            _dbContext.Configuration.LazyLoadingEnabled = false;
            _dbContext.Configuration.ValidateOnSaveEnabled = false;
        }
        #endregion

        public CarRepository Cars
        {
            get
            {
                return _carRepository ?? (_carRepository = new CarRepository(_dbContext));
            }
        }

        public SegmentRepository Segments
        {
            get
            {
                return _segmentRepository ?? (_segmentRepository = new SegmentRepository(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public Task CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        #region Dispose pattern
        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        #endregion
    }
}
