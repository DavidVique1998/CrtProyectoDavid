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
    public class CarritosController : Controller
    {
        private emmcomerseEntities db = new emmcomerseEntities();

        // GET: Carritos
        public ActionResult Index()
        {
            var carrito = db.Carrito.Include(c => c.Cliente);
            return View(carrito.ToList());
        }

        // GET: Carritos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrito carrito = db.Carrito.Find(id);
            if (carrito == null)
            {
                return HttpNotFound();
            }
            return View(carrito);
        }

        // GET: Carritos/Create
        public ActionResult Create()
        {
            ViewBag.cln_id = new SelectList(db.Cliente, "cln_id", "cln_tipo");
            return View();
        }

        // POST: Carritos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "car_id,cln_id,car_tipo")] Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                db.Carrito.Add(carrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cln_id = new SelectList(db.Cliente, "cln_id", "cln_tipo", carrito.cln_id);
            return View(carrito);
        }

        // GET: Carritos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrito carrito = db.Carrito.Find(id);
            if (carrito == null)
            {
                return HttpNotFound();
            }
            ViewBag.cln_id = new SelectList(db.Cliente, "cln_id", "cln_tipo", carrito.cln_id);
            return View(carrito);
        }

        // POST: Carritos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "car_id,cln_id,car_tipo")] Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cln_id = new SelectList(db.Cliente, "cln_id", "cln_tipo", carrito.cln_id);
            return View(carrito);
        }

        // GET: Carritos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrito carrito = db.Carrito.Find(id);
            if (carrito == null)
            {
                return HttpNotFound();
            }
            return View(carrito);
        }

        // POST: Carritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrito carrito = db.Carrito.Find(id);
            db.Carrito.Remove(carrito);
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
