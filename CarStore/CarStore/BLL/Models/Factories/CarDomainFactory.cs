using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public static class CarDomainFactory
    {
        public static CarDomainModel Create(Car car)
        {
            return new CarDomainModel
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Available = car.Available,
                SegmentId = car.SegmentId,

            };
        }

        public static CarDomainModel CreateCarDomain(this Car car)
        {
            return Create(car);
        }
    }
}
