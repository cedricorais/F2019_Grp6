using CemeteryManagementSystem.DataTest;
using CemeteryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CemeteryManagementSystem.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult TestDb()
        {
            List<TestModel> test = new List<TestModel>();
            test.Add(new TestModel("19-00000", "asd", "asd", "asd"));
            TestDAO testdao = new TestDAO();
            test = testdao.getData();

            return View("TestDb", test);
        }
    }
}