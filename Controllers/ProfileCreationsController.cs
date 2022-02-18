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
        private readonly demoDbEntities db;

     

        public ProfileCreationsController()
        {
            this.db = new demoDbEntities();
        }

        public ActionResult Index()
        {
            return View();
        }

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
            
                if (Session["UserId"] != null)
                {
                profileCreation.UserId = Convert.ToInt64(Session["UserId"]);
                if (ModelState.IsValid)
                {
                    db.ProfileCreations.Add(profileCreation);
                    db.SaveChanges();
                    ViewBag.SuccessMessage = "Details saved successfully";
                    return RedirectToAction("Create");
                }
            }

            ViewBag.UserId = new SelectList(db.UserRegistrations, "UserId", "UserName", profileCreation.UserId);
           
            return View(profileCreation);
        }
        
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    
        [HttpPost]
        public ActionResult Post(IEnumerable<string> applicationIds)
        {
            try
            {
                for (int i = 0; i < applicationIds.Count(); i++)
                {
                    var appId = Convert.ToInt64(applicationIds.ToList()[i]); var updateStatus = db.ProfileCreations.SingleOrDefault(x => x.ApplicationId == appId);
                    updateStatus.Status = 2; //Approved
                    db.SaveChanges();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { error = true });
            }
        }

       




    }
}
