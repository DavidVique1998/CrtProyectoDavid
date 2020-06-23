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
    public class ClientesController : Controller
    {


        // GET: Clientes
        public ActionResult Index()
        {
            
            return View(ClienteBLL.List());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = ClienteBLL.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.uso_id = new SelectList(UsuarioBLL.List(), "uso_id", "uso_usu");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cln_id,uso_id,cln_tipo,cln_dateOfCreated")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                ClienteBLL.Create(cliente);
                return RedirectToAction("Index");
            }

            ViewBag.uso_id = new SelectList(UsuarioBLL.List(), "uso_id", "uso_usu", cliente.uso_id);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = ClienteBLL.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.uso_id = new SelectList(UsuarioBLL.List(), "uso_id", "uso_usu", cliente.uso_id);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cln_id,uso_id,cln_tipo,cln_dateOfCreated")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                ClienteBLL.Update(cliente);
                return RedirectToAction("Index");
            }
            ViewBag.uso_id = new SelectList(UsuarioBLL.List(), "uso_id", "uso_usu", cliente.uso_id);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = ClienteBLL.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteBLL.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
