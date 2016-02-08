using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarStore.Models
{
    public static class SegmentDomainFactory
    {
        public static SegmentDomainModel Create(SegmentViewModel segmentView)
        {
            return new SegmentDomainModel
            {
                Id = segmentView.Id,
                CarSegment = segmentView.CarSegment,
            };
        }

        public static SegmentDomainModel CreateSegmentDomain(this SegmentViewModel segmentView)
        {
            return Create(segmentView);
        }
    }
}