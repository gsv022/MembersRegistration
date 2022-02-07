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
        private demoDbEntities2 db = new demoDbEntities2();
       

        // GET: UserRegistrations
        public ActionResult Index()
        {
            return View(db.UserRegistrations.ToList());
        }

        // GET: UserRegistrations/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistration userRegistration = db.UserRegistrations.Find(id);
            if (userRegistration == null)
            {
                return HttpNotFound();
            }
            return View(userRegistration);
        }

        // GET: UserRegistrations/Create
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
            return View("SignIn");
        }

        // GET: UserRegistrations/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistration userRegistration = db.UserRegistrations.Find(id);
            if (userRegistration == null)
            {
                return HttpNotFound();
            }
            return View(userRegistration);
        }

        // POST: UserRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,EmailId,Password,ConfirmPassword,IsAdmin")] UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRegistration);
        }

        // GET: UserRegistrations/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistration userRegistration = db.UserRegistrations.Find(id);
            if (userRegistration == null)
            {
                return HttpNotFound();
            }
            return View(userRegistration);
        }

        // POST: UserRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            UserRegistration userRegistration = db.UserRegistrations.Find(id);
            db.UserRegistrations.Remove(userRegistration);
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


        public ActionResult UserRegistration(int id = 0)
        {
            UserRegistration v = new UserRegistration();
            return View(v);
        }




        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }




        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(UserRegistration v)
        {
            try
            {
                using (demoDbEntities2 db = new demoDbEntities2())
                {
                    var usr = db.UserRegistrations.Single(u => u.UserName == v.UserName && u.Password == v.Password);
                    if (usr.IsAdmin == true)
                    {
                        Session["UserId"] = usr.UserId.ToString();
                        Session["UserName"] = usr.UserName.ToString();
                        return RedirectToAction("Admin");     //Admin
                    }
                    else if (usr == null || usr.IsAdmin == false)
                    {
                        Session["UserId"] = usr.UserId.ToString();
                        Session["UserName"] = usr.UserName.ToString();
                        return RedirectToAction("Applicant");  // User

                    }
                    


                }

            }
            catch (Exception)
            {
               MessageBox.Show( "Username or password is wrong");
                
            }

           
            return View();
        }




        public ActionResult Admin()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("SignIn");
            }

        }



        public ActionResult Applicant()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("SignIn");
            }

        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            // Session["UserId"] = null;
            //  Session["UserName"] = null;
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("SignIn", "UserRegistrations");
        }




    }
}
