using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarStore.Models;
using Microsoft.AspNet.Identity;
using BLL.Models;
using BLL.Services;

namespace CarStore.Controllers
{
    public class CarsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private readonly IBaseService<CarDomainModel> _carHandler;
        private readonly IBaseService<SegmentDomainModel> _segmentHandler;


        public CarsController(IBaseService<CarDomainModel> carHandler, IBaseService<SegmentDomainModel> segmentHandler)
        {
            _carHandler = carHandler;
            _segmentHandler = segmentHandler;
        }

        //public CarsController()
        //{
        //    db = new ApplicationDbContext();
        //}

        //public CarsController(Interface1 context)
        //{
        //    db = new ApplicationDbContext();
        //}

        // GET: Cars
        public ActionResult Index(string SearchString, int? SelectedSegment)
        {
            //ViewBag.Userid = User.Identity.GetUserId();
            var CarList = _carHandler.GetAll().Select(CarViewModelFactory.Create).ToList();
            ViewBag.SegmentList = ToSelectList(_segmentHandler.GetAll().Select(SegmentViewModelFactory.Create).ToList());

            if (!String.IsNullOrEmpty(SearchString))
            {
                CarList = CarList.Where(x => x.Make.ToLower().Contains(SearchString.ToLower()) || x.Model.ToLower().Contains(SearchString.ToLower())).ToList();
            }

            if(SelectedSegment!=null)
            {
                CarList = CarList.Where(x => x.SegmentId.Equals(SelectedSegment)).ToList();
            }
            return View(CarList);
        }

        public ActionResult MyCars()
        {
            string userId = User.Identity.GetUserId();
            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            //var CarList = db.Cars.Where(x => x.UserId == userId).ToList();
            var CarList = _carHandler.GetAll().Where(x => x.UserId == userId).ToList();
            return View(CarList);
        }

        public ActionResult Borrow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CarViewModel car = db.Cars.Find(id);
            CarViewModel car = _carHandler.GetById(id.Value).CreateCarViewModel();

            if (car == null)
            {
                return HttpNotFound();
            }
            car.Available = false;
            car.CreateCarDomain().UserId = User.Identity.GetUserId();
            //db.SaveChanges();
            _carHandler.Commit();    

            return RedirectToAction("Index");
        }

        public ActionResult Return(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //CarViewModel car = db.Cars.Find(id);
            CarViewModel car = _carHandler.GetById(id.Value).CreateCarViewModel();

            if (car == null)
            {
                return HttpNotFound();
            }
            car.Available = true;
            car.CreateCarDomain().UserId = null;
            //db.SaveChanges();
            _carHandler.Commit();   

            return RedirectToAction("Index");
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //CarViewModel car = db.Cars.Find(id);
            CarViewModel car = _carHandler.GetById(id.Value).CreateCarViewModel();

            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            //ViewBag.SegmentList = ToSelectList(db.Segments.ToList());
            ViewBag.SegmentList = ToSelectList(_segmentHandler.GetAll().Select(SegmentViewModelFactory.Create).ToList());

            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (CarViewModel car)
        {
            if (ModelState.IsValid)
            {
                _carHandler.Add(car.CreateCarDomain());
                _carHandler.Commit();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        public List<SelectListItem> ToSelectList(List<SegmentViewModel> Segment )
        {
            List<SelectListItem> Temp = new List<SelectListItem>();

            foreach (SegmentViewModel seg in Segment)
            {
                Temp.Add(new SelectListItem()
                {
                    Text = seg.CarSegment,
                    Value = seg.Id.ToString()
                });
            }
            return Temp;
        }

    // GET: Cars/Edit/5
    public ActionResult Edit(int? id)
        {
            //ViewBag.SegmentList = ToSelectList(db.Segments.ToList());
            ViewBag.SegmentList = ToSelectList(_segmentHandler.GetAll().Select(SegmentViewModelFactory.Create).ToList());

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CarViewModel car = db.Cars.Find(id); 
            CarViewModel car = _carHandler.GetById(id.Value).CreateCarViewModel();

            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (CarViewModel car)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(car).State = EntityState.Modified;
                //db.SaveChanges();
                _carHandler.Update(car.CreateCarDomain());
                _carHandler.Commit();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CarViewModel car = db.Cars.Find(id);
            CarViewModel car = _carHandler.GetById(id.Value).CreateCarViewModel();

            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //CarViewModel car = db.Cars.Find(id);
            //db.Cars.Remove(car);
            //db.SaveChanges();
            _carHandler.Delete(id);
            _carHandler.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _carHandler.Dispose();

            }
            base.Dispose(disposing);
        }
    }
}
