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
    public class CabezaFacturasController : Controller
    {

        // GET: CabezaFacturas
        public ActionResult Index()
        {
            return View(CabezaFacturaBLL.List());
        }

        // GET: CabezaFacturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CabezaFactura cabezaFactura = CabezaFacturaBLL.Get(id);
            if (cabezaFactura == null)
            {
                return HttpNotFound();
            }
            return View(cabezaFactura);
        }

        // GET: CabezaFacturas/Create
        public ActionResult Create()
        {
            ViewBag.cln_id = new SelectList(ClienteBLL.List(), "cln_id", "cln_tipo");
            return View();
        }

        // POST: CabezaFacturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cbf_id,cln_id,cbf_dateOfCreated")] CabezaFactura cabezaFactura)
        {
            if (ModelState.IsValid)
            {
                CabezaFacturaBLL.Create(cabezaFactura);
                return RedirectToAction("Index");
            }

            ViewBag.cln_id = new SelectList(ClienteBLL.List(), "cln_id", "cln_tipo", cabezaFactura.cln_id);
            return View(cabezaFactura);
        }

        // GET: CabezaFacturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CabezaFactura cabezaFactura = CabezaFacturaBLL.Get(id);
            if (cabezaFactura == null)
            {
                return HttpNotFound();
            }
            ViewBag.cln_id = new SelectList(ClienteBLL.List(), "cln_id", "cln_tipo", cabezaFactura.cln_id);
            return View(cabezaFactura);
        }

        // POST: CabezaFacturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cbf_id,cln_id,cbf_dateOfCreated")] CabezaFactura cabezaFactura)
        {
            if (ModelState.IsValid)
            {
                CabezaFacturaBLL.Update(cabezaFactura);
                return RedirectToAction("Index");
            }
            ViewBag.cln_id = new SelectList(ClienteBLL.List(), "cln_id", "cln_tipo", cabezaFactura.cln_id);
            return View(cabezaFactura);
        }

        // GET: CabezaFacturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CabezaFactura cabezaFactura =CabezaFacturaBLL.Get(id);
            if (cabezaFactura == null)
            {
                return HttpNotFound();
            }
            return View(cabezaFactura);
        }

        // POST: CabezaFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CabezaFacturaBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
