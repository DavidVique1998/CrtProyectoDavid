using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUCrtProyectoDavid;

namespace CrtProyectoDavid.Controllers
{
    public class PromocionesController : Controller
    {
        private emmcomerseEntities db = new emmcomerseEntities();

        // GET: Promociones
        public ActionResult Index()
        {
            return View(db.Promocion.ToList());
        }

        // GET: Promociones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocion promocion = db.Promocion.Find(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            return View(promocion);
        }

        // GET: Promociones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promociones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prm_id,prm_nom,prm_tip,prm_can,prm_por")] Promocion promocion)
        {
            if (ModelState.IsValid)
            {
                db.Promocion.Add(promocion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promocion);
        }

        // GET: Promociones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocion promocion = db.Promocion.Find(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            return View(promocion);
        }

        // POST: Promociones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prm_id,prm_nom,prm_tip,prm_can,prm_por")] Promocion promocion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promocion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promocion);
        }

        // GET: Promociones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocion promocion = db.Promocion.Find(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            return View(promocion);
        }

        // POST: Promociones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Promocion promocion = db.Promocion.Find(id);
            db.Promocion.Remove(promocion);
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
