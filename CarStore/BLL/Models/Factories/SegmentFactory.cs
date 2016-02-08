using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public static class SegmentFactory
    {
        public static Segment Create(SegmentDomainModel segmentDomain)
        {
            return new Segment
            {
                Id = segmentDomain.Id,
                CarSegment = segmentDomain.CarSegment,
            };
        }

        public static Segment CreateSegment(this SegmentDomainModel segmentDomain)
        {
            return Create(segmentDomain);
        }
    }
}
