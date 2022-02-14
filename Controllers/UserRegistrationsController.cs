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
    public class UserRegistrationsController : Controller
    {
        private readonly demoDbEntities db;

        public UserRegistrationsController()
        {
            this.db = new demoDbEntities();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,EmailId,Password,ConfirmPassword,IsAdmin")] UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                if (db.UserRegistrations.Where(u => u.UserName == userRegistration.UserName).Any())
                {
                    ViewBag.DuplicateMessage = "Username already exists";
                   
                   
                    return View("Create", userRegistration);
                }
                else
                {
                    db.UserRegistrations.Add(userRegistration);
                    
                    db.SaveChanges();
                    ViewBag.SuccessMessage = "Registration Successful";
                    
                    return RedirectToAction("SignIn");
                }
                
            }
            ModelState.Clear();
            return View("Create");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            Session["UserId"] = null;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(UserRegistration v)
        {
            try
            {
                    var user = db.UserRegistrations.Single(u => u.UserName == v.UserName && u.Password == v.Password);

                    Session["UserId"] = user.UserId.ToString();
                    Session["UserName"] = user.UserName.ToString();

                    GlobalVaribales.UserName = user.UserName.ToString();
                    GlobalVaribales.UserId = Convert.ToInt64(user.UserId);

                    if (user.IsAdmin == true)
                        GlobalVaribales.IsAdmin = true;
                    else if (user.IsAdmin == false)
                        GlobalVaribales.IsAdmin = false;

                    return RedirectToAction("Admin");  // User
            }
            catch (Exception e)
            {
               MessageBox.Show( "Username or password is wrong" + e);
                
            }

            return View();
        }

        public ActionResult Admin()
        {
            if (Session["UserId"] != null)
            {
                ViewBag.IsAdmin = GlobalVaribales.IsAdmin;
                var profileCreations = new List<ProfileCreation>();
                if (GlobalVaribales.IsAdmin)
                    profileCreations = db.ProfileCreations.Include(p => p.UserRegistration).ToList();

                else
                    profileCreations = db.ProfileCreations.Include(p => p.UserRegistration).Where(user=> user.UserId == GlobalVaribales.UserId).ToList();

                return View(profileCreations);

            }
            else
                return RedirectToAction("SignIn");

        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("SignIn", "UserRegistrations");
        }

        
    }
}
