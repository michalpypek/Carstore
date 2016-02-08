using DAL;

namespace BLL.Models
{
    public class CarDomainModel 
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public bool Available { get; set; }

        public int? SegmentId { get; set; }
        public virtual SegmentDomainModel Segment { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}