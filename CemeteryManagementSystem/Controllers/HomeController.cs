using CemeteryManagementSystem.Data;
using CemeteryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CemeteryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<ApplyModel> applyList = new List<ApplyModel>();
            ApplyDAO applyDao = new ApplyDAO();
            applyList = applyDao.getOssuaryTable();

            return View("Index", applyList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "CemSys";

            return View();
        }
    }
}