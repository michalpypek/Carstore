using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class SegmentService : BaseService<SegmentDomainModel>
    {
        public override void Add(SegmentDomainModel domainObject)
        {

            _dataSource.Segments.Add(domainObject.CreateSegment());
        }

        public override void Delete(SegmentDomainModel domainObject)
        {
            _dataSource.Segments.Delete(domainObject.CreateSegment());
        }

        public override void Delete(int domainObjectId)
        {
            _dataSource.Segments.Delete(domainObjectId);
        }

        public override IEnumerable<SegmentDomainModel> GetAll()
        {
            return _dataSource.Segments.GetAll().Select(SegmentDomainFactory.Create);
        }

        public override SegmentDomainModel GetById(int id)
        {
            return _dataSource.Segments.GetById(id).CreateSegmentDomain();
        }

        public override void Update(SegmentDomainModel domainObject)
        {
            _dataSource.Segments.Update(domainObject.CreateSegment());
        }
    }
}
