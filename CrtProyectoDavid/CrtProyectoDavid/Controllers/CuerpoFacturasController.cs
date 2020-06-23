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
    public class CuerpoFacturasController : Controller
    {

        // GET: CuerpoFacturas
        public ActionResult Index()
        {
            
            return View(CuerpoFacturaBLL.List());
        }

        // GET: CuerpoFacturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuerpoFactura cuerpoFactura = CuerpoFacturaBLL.Get(id);
            if (cuerpoFactura == null)
            {
                return HttpNotFound();
            }
            return View(cuerpoFactura);
        }

        // GET: CuerpoFacturas/Create
        public ActionResult Create()
        {
            ViewBag.cbf_id = new SelectList(CabezaFacturaBLL.List(), "cbf_id", "cbf_id");
            ViewBag.car_id = new SelectList(CarritoBLL.List(), "car_id", "car_tipo");
            return View();
        }

        // POST: CuerpoFacturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "crf_id,cbf_id,car_id")] CuerpoFactura cuerpoFactura)
        {
            if (ModelState.IsValid)
            {
                CuerpoFacturaBLL.Create(cuerpoFactura);
                return RedirectToAction("Index");
            }

            ViewBag.cbf_id = new SelectList(CabezaFacturaBLL.List(), "cbf_id", "cbf_id", cuerpoFactura.cbf_id);
            ViewBag.car_id = new SelectList(CarritoBLL.List(), "car_id", "car_tipo", cuerpoFactura.car_id);
            return View(cuerpoFactura);
        }

        // GET: CuerpoFacturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuerpoFactura cuerpoFactura = CuerpoFacturaBLL.Get(id);
            if (cuerpoFactura == null)
            {
                return HttpNotFound();
            }
            ViewBag.cbf_id = new SelectList(CabezaFacturaBLL.List(), "cbf_id", "cbf_id", cuerpoFactura.cbf_id);
            ViewBag.car_id = new SelectList(CarritoBLL.List(), "car_id", "car_tipo", cuerpoFactura.car_id);
            return View(cuerpoFactura);
        }

        // POST: CuerpoFacturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "crf_id,cbf_id,car_id")] CuerpoFactura cuerpoFactura)
        {
            if (ModelState.IsValid)
            {
                CuerpoFacturaBLL.Update(cuerpoFactura);
                return RedirectToAction("Index");
            }
            ViewBag.cbf_id = new SelectList(CabezaFacturaBLL.List(), "cbf_id", "cbf_id", cuerpoFactura.cbf_id);
            ViewBag.car_id = new SelectList(CarritoBLL.List(), "car_id", "car_tipo", cuerpoFactura.car_id);
            return View(cuerpoFactura);
        }

        // GET: CuerpoFacturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuerpoFactura cuerpoFactura = CuerpoFacturaBLL.Get(id);
            if (cuerpoFactura == null)
            {
                return HttpNotFound();
            }
            return View(cuerpoFactura);
        }

        // POST: CuerpoFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuerpoFacturaBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
