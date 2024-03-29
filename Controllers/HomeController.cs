﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using ContosoUniversity.ViewModels;

namespace contosoUniversity.Controllers
{
    public class HomeController : Controller

    {
        private SchoolContext db = new SchoolContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EnrollmentStats()
        {
            IQueryable<EnrollmentDateGroup> data = from student in db.Students
                                                   group student by student.EnrollmentDate into dateGroup
                                                   select new EnrollmentDateGroup()
                                                   {
                                                       EnrollmentDate = dateGroup.Key,
                                                       StudentCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }
        public ActionResult About()
        { 

            return View();
        }

        public ActionResult Contact()
        {
            

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}