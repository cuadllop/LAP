using LAP.Models;
using LAP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAP.Controllers
{
    public class BackOfficeController : Controller
    {
        // GET: BackOffice
        public ActionResult Index()
        {
            return View();
        }

        // GET: RunEngineForALlPendingApps
        [HttpGet]
        public ActionResult RunEngineForAllPendingApps()
        {
            List<LoanRequest> loanrequests =  Models_CRUD.GetAllPendingLoanRequests();
            LoanEngineService loanEngineService = new LoanEngineService();
            foreach (LoanRequest lr in loanrequests)
            {
                loanEngineService.AnalyzeApplication(lr);
            }

            return View();
        }



        // Get: RemoveAllLoanTypes
        [HttpGet]
        public ActionResult RemoveAllLoanTypes()
        {
            Models_CRUD.RemoveAllLoanTypes_WithoutLoanRequests();
            return View();
        }      

    }
}