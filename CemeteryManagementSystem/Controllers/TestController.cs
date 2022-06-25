using mvcnoauth.DataTest;
using mvcnoauth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcnoauth.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            List<TestModel> test = new List<TestModel>();
            test.Add(new TestModel("19-00000", "asd", "asd", "asd"));
            TestDAO testdao = new TestDAO();
            test = testdao.getData();

            return View("Index", test);
        }
    }
}