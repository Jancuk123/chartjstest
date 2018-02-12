using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChartJsLearning.Models;

namespace ChartJsLearning.Controllers
{
    public class PodatkisController : Controller
    {
        private MeteoContext db = new MeteoContext();

        // GET: Podatkis
        public ActionResult Index()
        {
            var podatki = (from x in db.Podatkis
                          orderby x.Datum
                          select x).ToList();

            var vlaga = (from v in db.Podatkis
                         orderby v.Datum
                         select v.Vlaga).ToList();
            ViewData["vlaga"] = vlaga;

            var temp = (from t in db.Podatkis
                        orderby t.Datum
                        select t.Temperatura).ToList();
            ViewData["vlaga"] = vlaga as List<decimal>;

            return View(podatki);
        }

        // GET: Podatkis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podatki podatki = db.Podatkis.Find(id);
            if (podatki == null)
            {
                return HttpNotFound();
            }
            return View(podatki);
        }

        // GET: Podatkis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Podatkis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Datum,Temperatura,Vlaga")] Podatki podatki)
        {
            if (ModelState.IsValid)
            {
                db.Podatkis.Add(podatki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(podatki);
        }

        // GET: Podatkis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podatki podatki = db.Podatkis.Find(id);
            if (podatki == null)
            {
                return HttpNotFound();
            }
            return View(podatki);
        }

        // POST: Podatkis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Datum,Temperatura,Vlaga")] Podatki podatki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(podatki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(podatki);
        }

        // GET: Podatkis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podatki podatki = db.Podatkis.Find(id);
            if (podatki == null)
            {
                return HttpNotFound();
            }
            return View(podatki);
        }

        // POST: Podatkis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Podatki podatki = db.Podatkis.Find(id);
            db.Podatkis.Remove(podatki);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
