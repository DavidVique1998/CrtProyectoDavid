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
    public class PagosController : Controller
    {

        // GET: Pagos
        public ActionResult Index()
        {
            return View(PagoBLL.List());
        }

        // GET: Pagos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = PagoBLL.Get(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // GET: Pagos/Create
        public ActionResult Create()
        {
            ViewBag.cln_id = new SelectList(ClienteBLL.List(), "cln_id", "cln_tipo");
            return View();
        }

        // POST: Pagos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pgo_id,cln_id,pgo_nom,pgo_ntg,pgo_fven,pgo_cseg")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                PagoBLL.Create(pago);
                return RedirectToAction("Index");
            }

            ViewBag.cln_id = new SelectList(ClienteBLL.List(), "cln_id", "cln_tipo", pago.cln_id);
            return View(pago);
        }

        // GET: Pagos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = PagoBLL.Get(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            ViewBag.cln_id = new SelectList(ClienteBLL.List(), "cln_id", "cln_tipo", pago.cln_id);
            return View(pago);
        }

        // POST: Pagos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pgo_id,cln_id,pgo_nom,pgo_ntg,pgo_fven,pgo_cseg")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                PagoBLL.Update(pago);
                return RedirectToAction("Index");
            }
            ViewBag.cln_id = new SelectList(ClienteBLL.List(), "cln_id", "cln_tipo", pago.cln_id);
            return View(pago);
        }

        // GET: Pagos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = PagoBLL.Get(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PagoBLL.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
