﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;
using static BikeSegura.Models.CambiosDianteiros;

namespace BikeSegura.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CambiosDianteirosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: CambiosDianteiros
        public ActionResult Index()
        {
            return View(db.CambiosDianteiros.Where(w => w.Ativo == 0).ToList());
        }

        // GET: CambiosDianteiros/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambiosDianteiros cambiosDianteiros = db.CambiosDianteiros.Find(id);
            if (cambiosDianteiros == null)
            {
                return HttpNotFound();
            }
            return View(cambiosDianteiros);
        }

        // GET: CambiosDianteiros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CambiosDianteiros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Velocidade,Ativo")] CambiosDianteiros cambiosDianteiros)
        {
            if (ModelState.IsValid)
            {
                db.CambiosDianteiros.Add(cambiosDianteiros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cambiosDianteiros);
        }

        // GET: CambiosDianteiros/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambiosDianteiros cambiosDianteiros = db.CambiosDianteiros.Find(id);
            if (cambiosDianteiros == null)
            {
                return HttpNotFound();
            }
            return View(cambiosDianteiros);
        }

        // POST: CambiosDianteiros/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Velocidade,Ativo")] CambiosDianteiros cambiosDianteiros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cambiosDianteiros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cambiosDianteiros);
        }

        // GET: CambiosDianteiros/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambiosDianteiros cambiosDianteiros = db.CambiosDianteiros.Find(id);
            if (cambiosDianteiros == null)
            {
                return HttpNotFound();
            }
            return View(cambiosDianteiros);
        }

        // POST: CambiosDianteiros/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CambiosDianteiros cambiosDianteiros = db.CambiosDianteiros.Find(id);
            cambiosDianteiros.Ativo = (OpcaoStatusCambiosDianteiros)1;
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
