using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MembersRegistration.Models;

namespace MembersRegistration.Controllers
{
    public class HomeController : Controller
    {
        private demoDbEntities db = new demoDbEntities();

     /*   public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Gender")
            {
                return View(db.ProfileCreations.Where(x => x.Gender == search || search == null).profileCreations.ToList());
            }
            else if(searchBy == "FirstName")
            {
                return View(db.ProfileCreations.Where(x => x.FirstName.StartsWith(search) || search == null).ToList());
            }
            else
            {
                ViewBag.DuplicateMessage = "Not found";
            }

            return View("Index");  
        }*/

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}