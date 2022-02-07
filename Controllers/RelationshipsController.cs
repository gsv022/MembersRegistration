using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MembersRegistration.Models;

namespace MembersRegistration.Controllers
{
    public class RelationshipsController : Controller
    {
        private demoDbEntities2 db = new demoDbEntities2();

         

        // GET: Relationships
        public ActionResult Index()
        {
            var relationships = db.Relationships.Include(r => r.ProfileCreation).Include(r => r.UserRegistration);
            return View(relationships.ToList());
        }

        // GET: Relationships/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationship relationship = db.Relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }
            return View(relationship);
        }

        // GET: Relationships/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationId = new SelectList(db.ProfileCreations, "ApplicationId", "FirstName");
            ViewBag.UserId = new SelectList(db.UserRegistrations, "UserId", "UserName");
            return View();
        }

        // POST: Relationships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RelationId,UserId,ApplicationId,Relation")] Relationship relationship)
        {
            if (ModelState.IsValid)
            {
                
                db.Relationships.Add(relationship);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.ApplicationId = new SelectList(db.ProfileCreations, "ApplicationId", "FirstName", relationship.ApplicationId);
            ViewBag.UserId = new SelectList(db.UserRegistrations, "UserId", "UserName", relationship.UserId);

            return View(relationship);
        }

        // GET: Relationships/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationship relationship = db.Relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationId = new SelectList(db.ProfileCreations, "ApplicationId", "FirstName", relationship.ApplicationId);
            ViewBag.UserId = new SelectList(db.UserRegistrations, "UserId", "UserName", relationship.UserId);
            return View(relationship);
        }

        // POST: Relationships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RelationId,UserId,ApplicationId,Relation")] Relationship relationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationId = new SelectList(db.ProfileCreations, "ApplicationId", "FirstName", relationship.ApplicationId);
            ViewBag.UserId = new SelectList(db.UserRegistrations, "UserId", "UserName", relationship.UserId);
            return View(relationship);
        }

        // GET: Relationships/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationship relationship = db.Relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }
            return View(relationship);
        }

        // POST: Relationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Relationship relationship = db.Relationships.Find(id);
            db.Relationships.Remove(relationship);
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
