﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Domain.Models;


namespace StatisticsWeb.Controllers
{
    public class StatisticsController : Controller
    {
        AppControler appControl = new AppControler();

        public ActionResult Index()
        {
            return View(appControl.goPrognostic());
        }


        [HttpGet]
        public ActionResult Calculate()
        {
            var prog = new ProgResult();

            return PartialView(prog);
        }


        [HttpPost]
        public ActionResult Calculate(Prognostic prognostic)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            var progResults = new ProgResultList();

            progResults.Add(appControl.calculateShare(prognostic));
            progResults.Add(appControl.calculateShare(prognostic,8));
            progResults.Add(appControl.calculateShare(prognostic,6));
            progResults.Add(appControl.calculateShare(prognostic,4));
           
            
            return PartialView(progResults);
        }
        
    }
}