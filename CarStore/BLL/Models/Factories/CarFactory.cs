using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public static class CarFactory
    {
        public static Car Create(CarDomainModel carDomain)
        {
            return new Car
            {
                Id = carDomain.Id,
                Make = carDomain.Make,
                Model = carDomain.Model,
                Available = carDomain.Available,
                SegmentId = carDomain.SegmentId,

            };
        }

        public static Car CreateCar(this CarDomainModel carDomain)
        {
            return Create(carDomain);
        }
    }
}
