using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public static class SegmentDomainFactory
    {
        public static SegmentDomainModel Create(Segment segment)
        {
            return new SegmentDomainModel
            {
                Id = segment.Id,
                CarSegment = segment.CarSegment,
            };
        }

        public static SegmentDomainModel CreateSegmentDomain(this Segment segment)
        {
            return Create(segment);
        }
    }
}
