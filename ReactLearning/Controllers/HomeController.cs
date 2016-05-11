using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReactLearning.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 基础用法
        /// </summary>
        /// <returns></returns>
        public ActionResult Basic()
        {
            return View();
        }

        public ActionResult Comment()
        {
            return View();
        }

        public ActionResult Pager()
        {
            return View();
        }

    }
}