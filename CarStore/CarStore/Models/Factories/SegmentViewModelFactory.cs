using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarStore.Models
{
    public static class SegmentViewModelFactory
    {
        public static SegmentViewModel Create(SegmentDomainModel segmentDomain)
        {
            return new SegmentViewModel
            {
                Id = segmentDomain.Id,
                CarSegment = segmentDomain.CarSegment,
            };
        }

        public static SegmentViewModel CreateSegmentViewModel(this SegmentDomainModel segmentDomain)
        {
            return Create(segmentDomain);
        }
    }
}