using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SegmentRepository : GenericRepository<Segment>, ISegmentRepository
    {
        public SegmentRepository(DbContext dbContext) : base (dbContext)
        {

        }
    }
}
