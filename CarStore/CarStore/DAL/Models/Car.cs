using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Car 
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public bool Available { get; set; }

        [ForeignKey("Segment")]
        public int? SegmentId { get; set; }
        public virtual Segment Segment { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}