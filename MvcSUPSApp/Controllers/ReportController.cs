using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigDes.DSchool.SUPS.DataAccess.Interface;
using DigDes.DSchool.SUPS.DataAccess.PresentData;

namespace MvcSUPSApp.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            List<ReportInfo> report = ReportPresent.GetAllReports();
            ViewData["report"] = report;
            return View();
        }

        [HttpPost]
        public ActionResult Index(ReportInfo report)
        {
            if (report.CarNumber != null)
            {
                List<ReportInfo> reports = ReportPresent.GetOneReport(report.CarNumber);
                ViewData["report"] = reports;
                return View();
            }
            else return View();
        }

    }
}
