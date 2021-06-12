using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Asp.net_MVC_TP_7.Models;

namespace Asp.net_MVC_TP_7.Controllers
{
    public class CommandesController : Controller
    {
        private VentesModelContainer db = new VentesModelContainer();

        // GET: Commandes
        public ActionResult Index()
        {
            var commandes = db.Commandes.Include(c => c.Client);
            return View(commandes.ToList());
        }

        // GET: Commandes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // GET: Commandes/Create
        public ActionResult Create()
        {
            ViewBag.Num_Clt = new SelectList(db.Clients, "Num_Clt", "Nom_Clt");
            return View();
        }

        // POST: Commandes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Num_Cmd,Date_Cmd,Num_Clt")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                db.Commandes.Add(commande);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Num_Clt = new SelectList(db.Clients, "Num_Clt", "Nom_Clt", commande.Num_Clt);
            return View(commande);
        }

        // GET: Commandes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            ViewBag.Num_Clt = new SelectList(db.Clients, "Num_Clt", "Nom_Clt", commande.Num_Clt);
            return View(commande);
        }

        // POST: Commandes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Num_Cmd,Date_Cmd,Num_Clt")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Num_Clt = new SelectList(db.Clients, "Num_Clt", "Nom_Clt", commande.Num_Clt);
            return View(commande);
        }

        // GET: Commandes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.Commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // POST: Commandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commande commande = db.Commandes.Find(id);
            db.Commandes.Remove(commande);
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
