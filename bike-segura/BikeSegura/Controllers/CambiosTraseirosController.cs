﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;
using static BikeSegura.Models.CambiosTraseiros;

namespace BikeSegura.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CambiosTraseirosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: CambiosTraseiros
        public ActionResult Index()
        {
            return View(db.CambiosTraseiros.Where(w => w.Ativo == 0).ToList());
        }

        // GET: CambiosTraseiros/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambiosTraseiros cambiosTraseiros = db.CambiosTraseiros.Find(id);
            if (cambiosTraseiros == null)
            {
                return HttpNotFound();
            }
            return View(cambiosTraseiros);
        }

        // GET: CambiosTraseiros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CambiosTraseiros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Velocidade,Ativo")] CambiosTraseiros cambiosTraseiros)
        {
            if (ModelState.IsValid)
            {
                db.CambiosTraseiros.Add(cambiosTraseiros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cambiosTraseiros);
        }

        // GET: CambiosTraseiros/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambiosTraseiros cambiosTraseiros = db.CambiosTraseiros.Find(id);
            if (cambiosTraseiros == null)
            {
                return HttpNotFound();
            }
            return View(cambiosTraseiros);
        }

        // POST: CambiosTraseiros/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Velocidade,Ativo")] CambiosTraseiros cambiosTraseiros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cambiosTraseiros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cambiosTraseiros);
        }

        // GET: CambiosTraseiros/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambiosTraseiros cambiosTraseiros = db.CambiosTraseiros.Find(id);
            if (cambiosTraseiros == null)
            {
                return HttpNotFound();
            }
            return View(cambiosTraseiros);
        }

        // POST: CambiosTraseiros/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CambiosTraseiros cambiosTraseiros = db.CambiosTraseiros.Find(id);
            cambiosTraseiros.Ativo = (OpcaoStatusCambiosTraseiros)1;
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
