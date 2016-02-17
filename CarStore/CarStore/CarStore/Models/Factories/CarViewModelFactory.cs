using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarStore.Models
{
    public static class CarViewModelFactory
    {
        public static CarViewModel Create(CarDomainModel carDomain)
        {
            return new CarViewModel
            {
                Id = carDomain.Id,
                Make = carDomain.Make,
                Model = carDomain.Model,
                Available = carDomain.Available,
                SegmentId = carDomain.SegmentId,

            };
        }

        public static CarViewModel CreateCarViewModel(this CarDomainModel carDomain)
        {
            return Create(carDomain);
        }
    }
}