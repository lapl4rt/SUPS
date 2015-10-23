using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigDes.DSchool.SUPS.DataAccess.PresentData;
using DigDes.DSchool.SUPS.DataAccess.Interface;

namespace MVCApp.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            List<ReportInfo> reportTable = ReportPresent.GetAllReports();
            ViewData["reportTable"] = reportTable;
            return View();
        }

    }
}
