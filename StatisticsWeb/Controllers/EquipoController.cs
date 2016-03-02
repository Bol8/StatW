using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;

namespace StatisticsWeb.Controllers
{
    public class EquipoController : Controller
    {
        AppControler appControl = new AppControler();

        
        public ActionResult Index()
        {
            return View(appControl.TotalResults().OrderByDescending(x=> x.Points));
        }

        public ActionResult HomeResults()
        {
            return View(appControl.HomeResults().OrderByDescending(x => x.Points));
        }

        public ActionResult AwayResults()
        {
            return View(appControl.AwayResults().OrderByDescending(x => x.Points));
        }

        public ActionResult AddTeams()
        {
            var success = appControl.addTeams();

            if (!success) return HttpNotFound();

            return RedirectToAction("Index");
        }


        public ActionResult TeamMatchs(string team)
        {
            return View(appControl.getMatchs(team));
        }
    }
}