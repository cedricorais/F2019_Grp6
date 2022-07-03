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
            return View(new ApplyModel());
        }

        public ActionResult TestDb()
        {
            List<ApplyModel> apply = new List<ApplyModel>();
            //apply.Add(new ApplyModel(0, "", "", "", "", "", "", ""));
            ApplyDAO applyDao = new ApplyDAO();
            apply = applyDao.getData();

            return View("TestDb", apply);
        }

        public ActionResult Create(ApplyModel applyModel)
        {
            ApplyDAO applyDao = new ApplyDAO();
            applyDao.insertData(applyModel);

            return View("Details", applyModel);
        }

        public ActionResult Edit(int Id)
        {
            ApplyDAO applyDao = new ApplyDAO();
            ApplyModel applyModel = applyDao.getAData(Id);

            return View("Index", applyModel);
        }

        public ActionResult Details(int Id)
        {
            ApplyDAO applyDao = new ApplyDAO();
            ApplyModel applyModel = applyDao.getAData(Id);

            return View("Details", applyModel);
        }
    }
}