using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class PratoController : Controller
    {
        
        private PratoContext db = new PratoContext();

        // GET: Prato
        public ActionResult Index()
        {
            return View(db.Pratoes.ToList());
        }

        public string ObjetoJson()
        {
            string json = JsonConvert.SerializeObject(new
            {
                results = new List<Prato>()
    {
                    new Prato { PratoId = 1, Name = "Prato Simples", Price = 15 },
                    new Prato { PratoId = 2, Name = "Prato Executivo", Price = 23 }
    }
            });
            return json;
        }

        // GET: Prato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratoes.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        public ActionResult Pedido()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Prato/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PratoId,Name,Price")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Pratoes.Add(prato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prato);
        }

        // GET: Prato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratoes.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // POST: Prato/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PratoId,Name,Price")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prato);
        }

        // GET: Prato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratoes.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // POST: Prato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prato prato = db.Pratoes.Find(id);
            db.Pratoes.Remove(prato);
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
