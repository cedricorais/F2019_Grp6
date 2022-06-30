using CemeteryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CemeteryManagementSystem.Controllers
{
    public class ApplyController : Controller
    {
        // GET: Apply
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowDetails(ApplyModel apply)
        {
            if (ModelState.IsValid)
                return View("ShowDetails", apply);
            else
                return View("Index");
        }
    }
}