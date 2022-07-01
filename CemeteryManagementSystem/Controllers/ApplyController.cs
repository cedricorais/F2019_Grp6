using CemeteryManagementSystem.Data;
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

        public ActionResult TestDb()
        {
            List<ApplyModel> apply = new List<ApplyModel>();
            //apply.Add(new ApplyModel(0, "", "", "", "", "", "", ""));
            ApplyDAO applydao = new ApplyDAO();
            apply = applydao.getData();

            return View("TestDb", apply);
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