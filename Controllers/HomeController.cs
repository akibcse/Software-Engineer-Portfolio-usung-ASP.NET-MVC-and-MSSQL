using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        MyPortfolioMVCEntities db = new MyPortfolioMVCEntities();
        public ActionResult Index()
        {
            var img = db.Images.Where(r => r.Status == true).OrderBy(r => r.Id);
            ViewBag.images = img;

            var abtme = db.AboutMes.Where(r => r.Status == true).OrderByDescending(r => r.Id).Take(1);
            ViewBag.aboutme = abtme;

            var skls = db.Skills.Where(r => r.Status == true).OrderBy(r => r.Id);
            ViewBag.skills = skls;
           
            var srvcs = db.Services.Where(r => r.Status == true).OrderBy(r => r.id);
            ViewBag.services = srvcs;

            var clnt = db.Clients.Where(r => r.Status == true).OrderBy(r => r.Id);
            ViewBag.clients = clnt;

            var rvs = db.Reviews.Where(r => r.Status == true).OrderBy(r => r.Id);
            ViewBag.reviews = rvs;

            var blg = db.Blogs.Where(r => r.Status == true).OrderBy(r => r.Id);
            ViewBag.blogs = blg;

            var prj = db.Projects.Where(r => r.Status == true).OrderBy(r => r.Id);
            ViewBag.projects = prj;

            return View();
        }


        //// GET: ContactUs/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ContactUs/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Email,Subject,Message,Status")] ContactU contactU)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ContactUs.Add(contactU);
        //        db.SaveChanges();

        //        if (User.IsInRole("Admin"))
        //        {

        //            return RedirectToAction("Index");
        //        }

        //        else
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }

        //    return View(contactU);
        //}

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