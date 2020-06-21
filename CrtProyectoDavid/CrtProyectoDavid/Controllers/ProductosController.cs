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
    public class ProductosController : Controller
    {
        private emmcomerseEntities db = new emmcomerseEntities();

        // GET: Productos
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Categoria).Include(p => p.Promocion);
            return View(producto.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.cat_id = new SelectList(db.Categoria, "cat_id", "cat_nom");
            ViewBag.prm_id = new SelectList(db.Promocion, "prm_id", "prm_nom");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prd_id,cat_id,prm_id,prd_nom,prd_img,prd_tal,prd_crt,prd_cnt,prd_dateOfCreated")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cat_id = new SelectList(db.Categoria, "cat_id", "cat_nom", producto.cat_id);
            ViewBag.prm_id = new SelectList(db.Promocion, "prm_id", "prm_nom", producto.prm_id);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.cat_id = new SelectList(db.Categoria, "cat_id", "cat_nom", producto.cat_id);
            ViewBag.prm_id = new SelectList(db.Promocion, "prm_id", "prm_nom", producto.prm_id);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prd_id,cat_id,prm_id,prd_nom,prd_img,prd_tal,prd_crt,prd_cnt,prd_dateOfCreated")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cat_id = new SelectList(db.Categoria, "cat_id", "cat_nom", producto.cat_id);
            ViewBag.prm_id = new SelectList(db.Promocion, "prm_id", "prm_nom", producto.prm_id);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
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
