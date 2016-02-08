using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarStore.Models
{
    public class CarViewModel 
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public bool Available { get; set; }

        public int? SegmentId { get; set; }
        public virtual SegmentViewModel Segment { get; set; }

        public CarViewModel()
        {
            Available = true;
        }
    }
}