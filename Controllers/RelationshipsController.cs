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
        private demoDbEntities db = new demoDbEntities();



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
            var userId = GlobalVaribales.UserId;

            ViewBag.UserId = userId;
            ViewBag.Profiles = db.ProfileCreations.Where(profile => profile.UserId == userId).ToList();
            ViewBag.Members = new SelectList(db.Members, "Id", "members");

            var updateRelationsList = new List<UpdateRelations>();

            foreach (var name in db.ProfileCreations.Where(profile => profile.UserId == userId).ToList())
            {
                var updateRelations = new UpdateRelations();
                updateRelations.ApplicationId = name.ApplicationId;
                updateRelations.UserId = name.UserId;
                updateRelations.ApplicationName = name.FirstName;
                updateRelationsList.Add(updateRelations);
            }

            return View(updateRelationsList);
        }

        // POST: Relationships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection frm)
        {
            var stuclass = frm.GetValues("profile.ApplicationId");
            var InstituteId = frm.GetValues("profile.UserId");
            var obtmark = frm.GetValues("profile.RelationId");

            for (int i = 0; i < stuclass.Count(); i++)
            {
                var appId = Convert.ToInt64(stuclass[i]);
                var relationship = new Relationship()
                {
                    ApplicationId = appId,
                    UserId = Convert.ToInt64(InstituteId[i]),
                    RelationId = Convert.ToInt64(obtmark[i])
                };
                var orgRelationship = db.Relationships.SingleOrDefault(x=> x.ApplicationId == appId);

                if (orgRelationship == null)
                {
                    db.Relationships.Add(relationship);
                }
                else
                {
                    orgRelationship.RelationId = relationship.RelationId;
                }

                db.SaveChanges();
            }

            if (ModelState.IsValid)
            {
                //foreach(var relationship in relationshipList.ToList())
                //{
                //    db.Relationships.Add(relationship);
                //    db.SaveChanges();
                //}

                return RedirectToAction("Create");
            }

            ViewBag.ApplicationId = new SelectList(db.ProfileCreations, "ApplicationId", "FirstName");
            ViewBag.UserId = new SelectList(db.UserRegistrations, "UserId", "UserName");

            return View();
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
                db.Entry(relationship).State = System.Data.Entity.EntityState.Modified;
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
