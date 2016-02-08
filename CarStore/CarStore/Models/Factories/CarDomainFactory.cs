using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarStore.Models
{
    public static class CarDomainFactory
    {
            public static CarDomainModel Create(CarViewModel carView)
            {
                return new CarDomainModel
                {
                    Id = carView.Id,
                    Make = carView.Make,
                    Model = carView.Model,
                    Available = carView.Available,
                    SegmentId = carView.SegmentId,

                };
            }

            public static CarDomainModel CreateCarDomain(this CarViewModel carView)
            {
                return Create(carView);
            }        
    }
}