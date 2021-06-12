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
    public class LigneCommandesController : Controller
    {
        private VentesModelContainer db = new VentesModelContainer();

        // GET: LigneCommandes
        public ActionResult Index()
        {
            var ligneCommandes = db.LigneCommandes.Include(l => l.Commande).Include(l => l.Article);
            return View(ligneCommandes.ToList());
        }

        // GET: LigneCommandes/Details/5
        public ActionResult Details(int numArt,int numCmd)
        {
            LigneCommande ligneCommande = db.LigneCommandes.Where(l => l.Num_Art == numArt && l.Num_Cmd == numCmd).Single();
            if (ligneCommande == null)
            {
                return HttpNotFound();
            }
            return View(ligneCommande);
        }

        // GET: LigneCommandes/Create
        public ActionResult Create()
        {
            ViewBag.Num_Cmd = new SelectList(db.Commandes, "Num_Cmd", "Num_Cmd");
            ViewBag.Num_Art = new SelectList(db.Articles, "Num_Art", "Nom_Art");
            return View();
        }

        // POST: LigneCommandes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Qtt,Num_Cmd,Num_Art")] LigneCommande ligneCommande)
        {
            if (ModelState.IsValid)
            {
                db.LigneCommandes.Add(ligneCommande);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Num_Cmd = new SelectList(db.Commandes, "Num_Cmd", "Num_Cmd", ligneCommande.Num_Cmd);
            ViewBag.Num_Art = new SelectList(db.Articles, "Num_Art", "Nom_Art", ligneCommande.Num_Art);
            return View(ligneCommande);
        }

        // GET: LigneCommandes/Edit/5
        public ActionResult Edit(int numArt,int numCmd)
        {
            LigneCommande ligneCommande = db.LigneCommandes.Where(l => l.Num_Art == numArt && l.Num_Cmd == numCmd).Single();
            if (ligneCommande == null)
            {
                return HttpNotFound();
            }
            ViewBag.Num_Cmd = new SelectList(db.Commandes, "Num_Cmd", "Num_Cmd", ligneCommande.Num_Cmd);
            ViewBag.Num_Art = new SelectList(db.Articles, "Num_Art", "Nom_Art", ligneCommande.Num_Art);
            return View(ligneCommande);
        }

        // POST: LigneCommandes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Qtt,Num_Cmd,Num_Art")] LigneCommande ligneCommande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ligneCommande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Num_Cmd = new SelectList(db.Commandes, "Num_Cmd", "Num_Cmd", ligneCommande.Num_Cmd);
            ViewBag.Num_Art = new SelectList(db.Articles, "Num_Art", "Nom_Art", ligneCommande.Num_Art);
            return View(ligneCommande);
        }

        // GET: LigneCommandes/Delete/5
        public ActionResult Delete(int numArt,int numCmd)
        {
            LigneCommande ligneCommande = db.LigneCommandes.Where(l => l.Num_Art == numArt && l.Num_Cmd == numCmd).Single();
            if (ligneCommande == null)
            {
                return HttpNotFound();
            }
            return View(ligneCommande);
        }

        // POST: LigneCommandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LigneCommande ligneCommande = db.LigneCommandes.Find(id);
            db.LigneCommandes.Remove(ligneCommande);
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
