using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Windows;
using MembersRegistration.Models;

namespace MembersRegistration.Controllers
{
    public class ProfileCreationsController : Controller
    {
        private demoDbEntities2 db = new demoDbEntities2();

        // GET: ProfileCreations
        public ActionResult Index()
        { 
                var profileCreations = db.ProfileCreations.Include(p => p.UserRegistration);
                return View(profileCreations.ToList());
            
        }

        // GET: ProfileCreations/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileCreation profileCreation = db.ProfileCreations.Find(id);
            if (profileCreation == null)
            {
                return HttpNotFound();
            }
            return View(profileCreation);
        }

        // GET: ProfileCreations/Create

      
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserRegistrations, "UserId", "UserName");
            return View();
        }

        // POST: ProfileCreations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]       
        [ValidateAntiForgeryToken]
              
        public ActionResult Create([Bind(Include = "ApplicationId,UserId,FirstName,MiddleName,LastName,Suffix,DateOfBirth,Gender")] ProfileCreation profileCreation)
        {
            if (ModelState.IsValid)
            {
                if (Session["UserId"] != null)
                {
                    db.ProfileCreations.Add(profileCreation);
                    MessageBox.Show("Details Saved Successfully");
                    db.SaveChanges();
                   
                    return RedirectToAction("Create");
                }
            }

            ViewBag.UserId = new SelectList(db.UserRegistrations, "UserId", "UserName", profileCreation.UserId);
            return View(profileCreation);
        }

        // GET: ProfileCreations/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileCreation profileCreation = db.ProfileCreations.Find(id);
            if (profileCreation == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserRegistrations, "UserId", "UserName", profileCreation.UserId);
            return View(profileCreation);
        }

        // POST: ProfileCreations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationId,UserId,FirstName,MiddleName,LastName,Suffix,DateOfBirth,Gender")] ProfileCreation profileCreation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profileCreation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserRegistrations, "UserId", "UserName", profileCreation.UserId);
            return View(profileCreation);
        }

        // GET: ProfileCreations/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileCreation profileCreation = db.ProfileCreations.Find(id);
            if (profileCreation == null)
            {
                return HttpNotFound();
            }
            return View(profileCreation);
        }

        // POST: ProfileCreations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProfileCreation profileCreation = db.ProfileCreations.Find(id);
            db.ProfileCreations.Remove(profileCreation);
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
