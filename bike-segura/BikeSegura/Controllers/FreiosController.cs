﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;
using static BikeSegura.Models.Freios;

namespace BikeSegura.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class FreiosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Freios
        public ActionResult Index()
        {
            return View(db.Freios.Where(w => w.Ativo == 0).ToList());
        }

        // GET: Freios/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Freios freios = db.Freios.Find(id);
            if (freios == null)
            {
                return HttpNotFound();
            }
            return View(freios);
        }

        // GET: Freios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Freios/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Ativo")] Freios freios)
        {
            if (ModelState.IsValid)
            {
                db.Freios.Add(freios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(freios);
        }

        // GET: Freios/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Freios freios = db.Freios.Find(id);
            if (freios == null)
            {
                return HttpNotFound();
            }
            return View(freios);
        }

        // POST: Freios/Edit        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ativo")] Freios freios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(freios);
        }

        // GET: Freios/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Freios freios = db.Freios.Find(id);
            if (freios == null)
            {
                return HttpNotFound();
            }
            return View(freios);
        }

        // POST: Freios/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Freios freios = db.Freios.Find(id);
            freios.Ativo = (OpcaoStatusFreios)1;
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
