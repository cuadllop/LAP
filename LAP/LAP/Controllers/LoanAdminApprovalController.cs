using LAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAP.Controllers
{
    public class LoanAdminApprovalController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: LoanAdminApproval
        public ActionResult Index()
        {
            return View();
        }

        // GET: GetPendingApprovalRequests
        public string GetPendingApprovalRequests()
        {
            //Retrieve the loan type that the customer will fill
            List<LoanRequest> loanrequestsToBeRated = Models_CRUD.GetAllRequestsConfirmedByEngine();
            return Newtonsoft.Json.JsonConvert.SerializeObject(loanrequestsToBeRated);
        }

        // POST: UpdateApprovalProcess
        public JsonResult UpdateApprovalProcess(List<LoanRequest> listLoanRequests)
        {
            try
            {
                foreach (LoanRequest l in listLoanRequests)
                {
                    Models_CRUD.UpdateStatusLoanRequest(l);
                }
            }
            catch (Exception)
            {
                return Json("", JsonRequestBehavior.AllowGet);            
            }
            return Json("Saved", JsonRequestBehavior.AllowGet);
        }
        
    }
}