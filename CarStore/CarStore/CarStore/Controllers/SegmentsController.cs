using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarStore.Models;
using BLL.Services;
using BLL.Models;

namespace CarStore.Controllers
{
    public class SegmentsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private readonly IBaseService<SegmentDomainModel> _segmentHandler;

        public SegmentsController( IBaseService<SegmentDomainModel> segmentHandler)
        {
            _segmentHandler = segmentHandler;
        }
        // GET: Segments
        public ActionResult Index()
        {
            return View(_segmentHandler.GetAll().Select(SegmentViewModelFactory.Create).ToList());
        }

        // GET: Segments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //SegmentViewModel segment = db.Segments.Find(id);
            SegmentViewModel segment = _segmentHandler.GetById(id.Value).CreateSegmentViewModel();

            if (segment == null)
            {
                return HttpNotFound();
            }
            return View(segment);
        }

        // GET: Segments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Segments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SegmentId,CarSegment")] SegmentViewModel segment)
        {
            if (ModelState.IsValid)
            {
                //db.Segments.Add(segment);
                //db.SaveChanges();
                _segmentHandler.Add(segment.CreateSegmentDomain());
                _segmentHandler.Commit();
                return RedirectToAction("Index");
            }

            return View(segment);
        }

        // GET: Segments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //SegmentViewModel segment = db.Segments.Find(id);
            SegmentViewModel segment = _segmentHandler.GetById(id.Value).CreateSegmentViewModel();

            if (segment == null)
            {
                return HttpNotFound();
            }
            return View(segment);
        }

        // POST: Segments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SegmentId,CarSegment")] SegmentViewModel segment)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(segment).State = EntityState.Modified;
                //db.SaveChanges();
                _segmentHandler.Update(segment.CreateSegmentDomain());
                _segmentHandler.Commit();

                return RedirectToAction("Index");
            }
            return View(segment);
        }

        // GET: Segments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //SegmentViewModel segment = db.Segments.Find(id);
            SegmentViewModel segment = _segmentHandler.GetById(id.Value).CreateSegmentViewModel();

            if (segment == null)
            {
                return HttpNotFound();
            }
            return View(segment);
        }

        // POST: Segments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //SegmentViewModel segment = db.Segments.Find(id);
            //db.Segments.Remove(segment);
            //db.SaveChanges();
            _segmentHandler.Delete(id);
            _segmentHandler.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _segmentHandler.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
