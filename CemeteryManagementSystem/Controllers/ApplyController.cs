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
            ApplyDAO applydao = new ApplyDAO();
            apply = applydao.getData();

            return View("TestDb", apply);
        }

        public ActionResult Create(ApplyModel applymodel)
        {
            ApplyDAO applydao = new ApplyDAO();
            applydao.insertData(applymodel);

            return View("Details", applymodel);
        }

        public ActionResult Edit(int Id)
        {
            ApplyDAO applydao = new ApplyDAO();
            ApplyModel applymodel = applydao.getAData(Id);

            return View("Index", applymodel);
        }

        public ActionResult Details(int Id)
        {
            ApplyDAO applydao = new ApplyDAO();
            ApplyModel applymodel = applydao.getAData(Id);

            return View("Details", applymodel);
        }
    }
}