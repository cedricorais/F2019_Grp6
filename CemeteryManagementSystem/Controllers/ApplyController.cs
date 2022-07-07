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

        [HttpPost]
        public ActionResult InsertApplicant(ApplyModel applyModel)
        {
            ApplyDAO applyDao = new ApplyDAO();
            applyDao.insertApplicantData(applyModel);

            return View("ApplicantDetails", applyModel);
        }

        [HttpPost]
        public ActionResult InsertOssuary(ApplyModel applyModel)
        {
            ApplyDAO applyDao = new ApplyDAO();
            applyDao.insertOssuaryData(applyModel);

            return View("OssuaryDetails", applyModel);
        }

        [Authorize]
        public ActionResult Database()
        {
            List<ApplyModel> applyList = new List<ApplyModel>();
            //apply.Add(new ApplyModel(0, "", "", "", "", "", "", ""));
            ApplyDAO applyDao = new ApplyDAO();
            applyList = applyDao.getApplicantTable();

            return View("Database", applyList);
        }

        public ActionResult Ossuary()
        {
            List<ApplyModel> applyList = new List<ApplyModel>();
            ApplyDAO applyDao = new ApplyDAO();
            applyList = applyDao.getOssuaryTable();

            return View("Ossuary", applyList);
        }

        //public ActionResult Ossuary(int page)
        //{
        //    List<ApplyModel> applyList = new List<ApplyModel>();
        //    ApplyDAO applyDao = new ApplyDAO();
        //    ViewBag.Message = page;
        //    switch (page)
        //    {
        //        case 1:
        //            applyList = applyDao.getOssuaryTable(page);
        //            ViewBag.Title = "Ossuary I";
        //            break;
        //        case 2:
        //            applyList = applyDao.getOssuaryTable(page);
        //            ViewBag.Title = "Ossuary II";
        //            break;
        //        case 3:
        //            applyList = applyDao.getOssuaryTable(page);
        //            ViewBag.Title = "Ossuary III";
        //            break;
        //        case 4:
        //            applyList = applyDao.getOssuaryTable(page);
        //            ViewBag.Title = "Ossuary IV";
        //            break;
        //        case 5:
        //            applyList = applyDao.getOssuaryTable(page);
        //            ViewBag.Title = "Ossuary V";
        //            break;
        //        case 6:
        //            applyList = applyDao.getOssuaryTable(page);
        //            ViewBag.Title = "Ossuary VI";
        //            break;
        //        case 7:
        //            applyList = applyDao.getOssuaryTable(page);
        //            ViewBag.Title = "Ossuary VII";
        //            break;
        //        case 8:
        //            applyList = applyDao.getOssuaryTable(page);
        //            ViewBag.Title = "Ossuary VIII";
        //            break;
        //        case 9:
        //            applyList = applyDao.getOssuaryTable(page);
        //            ViewBag.Title = "Ossuary IX";
        //            break;
        //        case 10:
        //            applyList = applyDao.getOssuaryTable(page);
        //            ViewBag.Title = "Ossuary X";
        //            break;
        //        default:
        //            return View("../Shared/Error");
        //    }

        //    return View("Ossuary", applyList);
        //}

        public ActionResult EditApplicant(int Id)
        {
            ApplyDAO applyDao = new ApplyDAO();
            ApplyModel applyModel = applyDao.get1ApplicantData(Id);

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

                return View("EditApplicant", applyModel);
            }
            else
            {
                return View("../Shared/Error");
            }
        }

        public ActionResult EditOssuary(int Id)
        {
            ApplyDAO applyDao = new ApplyDAO();
            ApplyModel applyModel = applyDao.get1OssuaryData(Id);

            if (ModelState.IsValid)
            {
                List<SelectListItem> gender = new List<SelectListItem>();
                gender.Add(new SelectListItem() { Text = "Male", Value = "Male" });
                gender.Add(new SelectListItem() { Text = "Female", Value = "Female" });
                gender.Add(new SelectListItem() { Text = "Other", Value = "Other" });
                applyModel.deadGender = new SelectList(gender, "Value", "Text", 0);

                List<SelectListItem> location = new List<SelectListItem>();
                location.Add(new SelectListItem() { Text = "Ossuary I", Value = "Ossuary I" });
                location.Add(new SelectListItem() { Text = "Ossuary II", Value = "Ossuary II" });
                location.Add(new SelectListItem() { Text = "Ossuary III", Value = "Ossuary III" });
                location.Add(new SelectListItem() { Text = "Ossuary IV", Value = "Ossuary IV" });
                location.Add(new SelectListItem() { Text = "Ossuary V", Value = "Ossuary V" });
                location.Add(new SelectListItem() { Text = "Ossuary VI", Value = "Ossuary VI" });
                location.Add(new SelectListItem() { Text = "Ossuary VII", Value = "Ossuary VII" });
                location.Add(new SelectListItem() { Text = "Ossuary VIII", Value = "Ossuary VIII" });
                location.Add(new SelectListItem() { Text = "Ossuary IX", Value = "Ossuary IX" });
                location.Add(new SelectListItem() { Text = "Ossuary X", Value = "Ossuary X" });
                applyModel.location = new SelectList(location, "Value", "Text", 0);

                List<SelectListItem> floorNSection = new List<SelectListItem>();
                floorNSection.Add(new SelectListItem() { Text = "A1", Value = "A1" });
                floorNSection.Add(new SelectListItem() { Text = "A2", Value = "A2" });
                floorNSection.Add(new SelectListItem() { Text = "A3", Value = "A3" });
                floorNSection.Add(new SelectListItem() { Text = "A4", Value = "A4" });
                floorNSection.Add(new SelectListItem() { Text = "A5", Value = "A5" });
                floorNSection.Add(new SelectListItem() { Text = "B1", Value = "B1" });
                floorNSection.Add(new SelectListItem() { Text = "B2", Value = "B2" });
                floorNSection.Add(new SelectListItem() { Text = "B3", Value = "B3" });
                floorNSection.Add(new SelectListItem() { Text = "B4", Value = "B4" });
                floorNSection.Add(new SelectListItem() { Text = "B5", Value = "B5" });
                floorNSection.Add(new SelectListItem() { Text = "C1", Value = "C1" });
                floorNSection.Add(new SelectListItem() { Text = "C2", Value = "C2" });
                floorNSection.Add(new SelectListItem() { Text = "C3", Value = "C3" });
                floorNSection.Add(new SelectListItem() { Text = "C4", Value = "C4" });
                floorNSection.Add(new SelectListItem() { Text = "C5", Value = "C5" });
                floorNSection.Add(new SelectListItem() { Text = "D1", Value = "D1" });
                floorNSection.Add(new SelectListItem() { Text = "D2", Value = "D2" });
                floorNSection.Add(new SelectListItem() { Text = "D3", Value = "D3" });
                floorNSection.Add(new SelectListItem() { Text = "D4", Value = "D4" });
                floorNSection.Add(new SelectListItem() { Text = "D5", Value = "D5" });
                applyModel.floorNSection = new SelectList(floorNSection, "Value", "Text", 0);

                return View("EditOssuary", applyModel);
            }
            else
            {
                return View("../Shared/Error");
            }
        }

        public ActionResult ApplicantDetails(int Id)
        {
            ApplyDAO applyDao = new ApplyDAO();
            ApplyModel applyModel = applyDao.get1ApplicantData(Id);

            return View("ApplicantDetails", applyModel);
        }

        public ActionResult OssuaryDetails(int Id)
        {
            ApplyDAO applyDao = new ApplyDAO();
            ApplyModel applyModel = applyDao.get1OssuaryData(Id);

            return View("OssuaryDetails", applyModel);
        }

        public ActionResult DeleteApplicant(int Id)
        {
            ApplyDAO applyDao = new ApplyDAO();
            applyDao.deleteApplicant(Id);
            List<ApplyModel> applyList = applyDao.getApplicantTable();

            return View("Delete", applyList);
        }

        public ActionResult DeleteOssuary(int Id)
        {
            ApplyDAO applyDao = new ApplyDAO();
            applyDao.deleteOssuary(Id);
            List<ApplyModel> applyList = applyDao.getOssuaryTable();

            return View("Delete", applyList);
        }

        public ActionResult SearchForLast(string searchTerm)
        {
            ApplyDAO applyDao = new ApplyDAO();
            List<ApplyModel> searchResult = applyDao.searchForLast(searchTerm);

            return View("../Home/Index", searchResult);
        }
    }
}