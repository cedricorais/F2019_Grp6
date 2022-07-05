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
            ApplyModel applyModel = new ApplyModel();
            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem() { Text = "Male", Value = "Male" });
            gender.Add(new SelectListItem() { Text = "Female", Value = "Female" });
            gender.Add(new SelectListItem() { Text = "Other", Value = "Other" });
            applyModel.applicantGender = new SelectList(gender, "Value", "Text", 0);

            List<SelectListItem> payment = new List<SelectListItem>();
            payment.Add(new SelectListItem() { Text = "Down Payment", Value = "Down Payment" });
            payment.Add(new SelectListItem() { Text = "Full Payment", Value = "Full Payment" });
            applyModel.paymentMethod = new SelectList(payment, "Value", "Text", 0);

            List<SelectListItem> gender2 = new List<SelectListItem>();
            gender2.Add(new SelectListItem() { Text = "Male", Value = "Male" });
            gender2.Add(new SelectListItem() { Text = "Female", Value = "Female" });
            gender2.Add(new SelectListItem() { Text = "Other", Value = "Other" });
            applyModel.deadGender = new SelectList(gender2, "Value", "Text", 0);

            return View(applyModel);
        }

        public ActionResult Database()
        {
            List<ApplyModel> applyList = new List<ApplyModel>();
            //apply.Add(new ApplyModel(0, "", "", "", "", "", "", ""));
            ApplyDAO applyDao = new ApplyDAO();
            applyList = applyDao.getApplicantData();

            return View("Database", applyList);
        }

        [HttpPost]
        public ActionResult Create(ApplyModel applyModel)
        {
            ApplyDAO applyDao = new ApplyDAO();
            applyDao.insertData(applyModel);

            return View("Details", applyModel);
        }
        
        public ActionResult Edit(int Id)
        {
            ApplyDAO applyDao = new ApplyDAO();
            ApplyModel applyModel = applyDao.get1Data(Id);

            if (ModelState.IsValid)
            {
                List<SelectListItem> gender = new List<SelectListItem>();
                gender.Add(new SelectListItem() { Text = "Male", Value = "Male" });
                gender.Add(new SelectListItem() { Text = "Female", Value = "Female" });
                gender.Add(new SelectListItem() { Text = "Other", Value = "Other" });
                applyModel.applicantGender = new SelectList(gender, "Value", "Text", 0);

                List<SelectListItem> payment = new List<SelectListItem>();
                payment.Add(new SelectListItem() { Text = "Down Payment", Value = "Down Payment" });
                payment.Add(new SelectListItem() { Text = "Full Payment", Value = "Full Payment" });
                applyModel.paymentMethod = new SelectList(payment, "Value", "Text", 0);

                List<SelectListItem> gender2 = new List<SelectListItem>();
                gender2.Add(new SelectListItem() { Text = "Male", Value = "Male" });
                gender2.Add(new SelectListItem() { Text = "Female", Value = "Female" });
                gender2.Add(new SelectListItem() { Text = "Other", Value = "Other" });
                applyModel.deadGender = new SelectList(gender2, "Value", "Text", 0);

                return View("Index", applyModel);
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Delete(int Id)
        {
            ApplyDAO applyDao = new ApplyDAO();
            applyDao.Delete(Id);
            List<ApplyModel> applyList = applyDao.getApplicantData();

            return View("Database", applyList);
        }

        public ActionResult Details(int Id)
        {
            ApplyDAO applyDao = new ApplyDAO();
            ApplyModel applyModel = applyDao.get1Data(Id);

            return View("Details", applyModel);
        }

        public ActionResult SearchForLast(string searchTerm)
        {
            ApplyDAO applyDao = new ApplyDAO();
            List<ApplyModel> searchResult = applyDao.searchForLast(searchTerm);

            return View("Database", searchResult);
        }
    }
}