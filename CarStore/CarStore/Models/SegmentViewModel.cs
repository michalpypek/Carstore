using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarStore.Models
{
    public class SegmentViewModel
    {        
        public int Id { get; set; }
        public string CarSegment { get; set; }
    }
}