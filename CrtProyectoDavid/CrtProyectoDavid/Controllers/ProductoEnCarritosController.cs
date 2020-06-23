﻿using System;
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
    public class ProductoEnCarritosController : Controller
    {
        
        // GET: ProductoEnCarritos
        public ActionResult Index()
        {
           return View(ProductoEnCarritoBLL.List());
        }

        // GET: ProductoEnCarritos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoEnCarrito productoEnCarrito = ProductoEnCarritoBLL.Get(id);
            if (productoEnCarrito == null)
            {
                return HttpNotFound();
            }
            return View(productoEnCarrito);
        }

        // GET: ProductoEnCarritos/Create
        public ActionResult Create()
        {
            ViewBag.car_id = new SelectList(CarritoBLL.List(), "car_id", "car_tipo");
            ViewBag.prd_id = new SelectList(ProductoBLL.List(), "prd_id", "prd_nom");
            return View();
        }

        // POST: ProductoEnCarritos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pcr_id,car_id,prd_id,pcr_est,prd_cnt,pcr_dateOfCreated")] ProductoEnCarrito productoEnCarrito)
        {
            if (ModelState.IsValid)
            {
                ProductoEnCarritoBLL.Create(productoEnCarrito);
                return RedirectToAction("Index");
            }

            ViewBag.car_id = new SelectList(CarritoBLL.List(), "car_id", "car_tipo", productoEnCarrito.car_id);
            ViewBag.prd_id = new SelectList(ProductoBLL.List(), "prd_id", "prd_nom", productoEnCarrito.prd_id);
            return View(productoEnCarrito);
        }

        // GET: ProductoEnCarritos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoEnCarrito productoEnCarrito = ProductoEnCarritoBLL.Get(id);
            if (productoEnCarrito == null)
            {
                return HttpNotFound();
            }
            ViewBag.car_id = new SelectList(CarritoBLL.List(), "car_id", "car_tipo", productoEnCarrito.car_id);
            ViewBag.prd_id = new SelectList(ProductoBLL.List(), "prd_id", "prd_nom", productoEnCarrito.prd_id);
            return View(productoEnCarrito);
        }

        // POST: ProductoEnCarritos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pcr_id,car_id,prd_id,pcr_est,prd_cnt,pcr_dateOfCreated")] ProductoEnCarrito productoEnCarrito)
        {
            if (ModelState.IsValid)
            {
                ProductoEnCarritoBLL.Update(productoEnCarrito);
                return RedirectToAction("Index");
            }
            ViewBag.car_id = new SelectList(CarritoBLL.List(), "car_id", "car_tipo", productoEnCarrito.car_id);
            ViewBag.prd_id = new SelectList(ProductoBLL.List(), "prd_id", "prd_nom", productoEnCarrito.prd_id);
            return View(productoEnCarrito);
        }

        // GET: ProductoEnCarritos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoEnCarrito productoEnCarrito = ProductoEnCarritoBLL.Get(id);
            if (productoEnCarrito == null)
            {
                return HttpNotFound();
            }
            return View(productoEnCarrito);
        }

        // POST: ProductoEnCarritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoEnCarritoBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}