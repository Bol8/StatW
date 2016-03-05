using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;

namespace StatisticsWeb.Controllers
{
    public class AppManageController : Controller
    {

        // GET: AppManage
        public ActionResult Update()
        {
            AppManage.UpdateMatchs();


            return View();
        }
    }
}