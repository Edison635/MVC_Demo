using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.CommandTrees;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Demo.Models;

namespace MVC_Demo.Controllers
{
    public class MoiveController : Controller
    {
        private MoiveDbContext db = new MoiveDbContext();

        //
        // GET: /Moive/

        public ActionResult Index()
        {
            return View(db.Moives.ToList());
        }

        //
        // GET: /Moive/Details/5

        public ActionResult Details(int id = 0)
        {
            Moive moive = db.Moives.Find(id);
            if (moive == null)
            {
                return HttpNotFound();
            }
            return View(moive);
        }

        //
        // GET: /Moive/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Moive/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Moive moive)
        {
            if (ModelState.IsValid)
            {
                db.Moives.Add(moive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moive);
        }

        //
        // GET: /Moive/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Moive moive = db.Moives.Find(id);
            if (moive == null)
            {
                return HttpNotFound();
            }
            return View(moive);
        }

        //
        // POST: /Moive/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Moive moive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moive);
        }

        //
        // GET: /Moive/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Moive moive = db.Moives.Find(id);
            if (moive == null)
            {
                return HttpNotFound();
            }
            return View(moive);
        }

        //
        // POST: /Moive/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moive moive = db.Moives.Find(id);
            db.Moives.Remove(moive);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult SearchIndex(string moiveGeren,string SearchString)
        {
            var geren = new List<string>();
            var querygeren = from p in db.Moives
                orderby p.Genre
                select p.Genre;
            geren.AddRange(querygeren.Distinct());

            ViewBag.moiveGeren = new SelectList(geren);

            var moives = from m in db.Moives
                select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                moives = moives.Where(c => c.Title.Contains(SearchString));
            }
            if (string.IsNullOrEmpty(moiveGeren))
                return View(moives);
            return View(moives.Where(c => c.Genre == moiveGeren));
            
        }
    }
}