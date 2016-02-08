using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CarService : BaseService<CarDomainModel>
    {
        void AssignUser(CarDomainModel model, string userId)
        {
            model.CreateCar().UserId = userId;
        }

        public override void Add(CarDomainModel domainObject)
        {

            _dataSource.Cars.Add(domainObject.CreateCar());
        }

        public override void Delete(CarDomainModel domainObject)
        {
            _dataSource.Cars.Delete(domainObject.CreateCar());
        }

        public override void Delete(int domainObjectId)
        {
            _dataSource.Cars.Delete(domainObjectId);
        }

        public override IEnumerable<CarDomainModel> GetAll()
        {
            return _dataSource.Cars.GetAll().Select(CarDomainFactory.Create);
        }

        public override CarDomainModel GetById(int id)
        {
            return _dataSource.Cars.GetById(id).CreateCarDomain();
        }

        public override void Update(CarDomainModel domainObject)
        {
            _dataSource.Cars.Update(domainObject.CreateCar());
        }
    }
}
