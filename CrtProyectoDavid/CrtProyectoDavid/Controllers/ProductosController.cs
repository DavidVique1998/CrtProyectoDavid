using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUCrtProyectoDavid;
using BEUCrtProyectoDavid.Queris;

namespace CrtProyectoDavid.Controllers
{
    public class ProductosController : Controller
    {
        

        // GET: Productos
        public ActionResult Index()
        {
            
            return View(ProductoBLL.List());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = ProductoBLL.Get(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.cat_id = new SelectList(CategoriaBLL.List(), "cat_id", "cat_nom");
            ViewBag.prm_id = new SelectList(PromocionBLL.List(), "prm_id", "prm_nom");
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
                ProductoBLL.Create(producto);
                return RedirectToAction("Index");
            }

            ViewBag.cat_id = new SelectList(CategoriaBLL.List(), "cat_id", "cat_nom", producto.cat_id);
            ViewBag.prm_id = new SelectList(PromocionBLL.List(), "prm_id", "prm_nom", producto.prm_id);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = ProductoBLL.Get(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.cat_id = new SelectList(CategoriaBLL.List(), "cat_id", "cat_nom", producto.cat_id);
            ViewBag.prm_id = new SelectList(PromocionBLL.List(), "prm_id", "prm_nom", producto.prm_id);
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
                ProductoBLL.Update(producto);
                return RedirectToAction("Index");
            }
            ViewBag.cat_id = new SelectList(CategoriaBLL.List(), "cat_id", "cat_nom", producto.cat_id);
            ViewBag.prm_id = new SelectList(PromocionBLL.List(), "prm_id", "prm_nom", producto.prm_id);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = ProductoBLL.Get(id);
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
            ProductoBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
