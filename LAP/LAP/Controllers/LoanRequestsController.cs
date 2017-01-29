using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LAP.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace LAP.Controllers
{
    public class LoanRequestsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: LoanRequests
        public ActionResult Index()
        {
            var loanRequests = db.LoanRequests.Include(l => l.LoanType);

            //Retrieve the loan type that the customer will fill
            List<LoanType> loanTypes = Models_CRUD.GetAllLoanType();
            LoanType loanType = loanTypes.FirstOrDefault(x => x.Name == "basic configuration");

            return View(loanType);
        }

        // GET: LoanRequests/ReturnPendingRequests
        public ActionResult ReturnPendingRequests()
        {
            List<LoanRequest> loanRequests = Models_CRUD.GetAllRequestsConfirmedByEngine();
            return View(loanRequests);
        }


        // GET: LoanRequests/ReturnPendingRequests/email
        public String ReturnCustomerRequests(string email)
        {
            List<LoanRequest> loanRequests;
            User usr = Models_CRUD.GetUserByEmail(email);
            if (usr!=null)
            { 
            int userid = Models_CRUD.GetUserByEmail(email).Id;
            loanRequests = Models_CRUD.GetAllLoanRequestsByUserId(userid)
                .OrderByDescending(x=>x.SubmitDate).ToList();
            
            }
            else 
            {
                loanRequests = new List<LoanRequest>();
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(loanRequests);
        }

        // POST: LoanRequests/Create
        [HttpPost]
        public JsonResult Create(LoanRequest loanRequest)
        {
            try
            {
                loanRequest.LoanType = db.LoanTypes.First(x => x.Id == loanRequest.LoanTypeId);
                string email = loanRequest.User.Email;
                string name = loanRequest.User.Name;
                loanRequest.User = db.Users.FirstOrDefault(x => x.Email == loanRequest.User.Email);
                loanRequest.Status = (int)Services.Definition.Status.Pending;

                if (loanRequest.User == null)
                {
                    User usr = new User();
                    usr.Role = new Role();
                    usr.Role.Name = "Customer";
                    usr.Role.Id = 1;
                    usr.Email = email;
                    usr.Name = name;
                    loanRequest.User = db.Users.Add(usr);
                }

                loanRequest.FormFields.All(x => x.LoanRequest == loanRequest);
                loanRequest.SubmitDate = DateTime.Now;
                db.LoanRequests.Add(loanRequest);
                db.SaveChanges();
                loanRequest.User.LoanRequests = null;
                loanRequest.User.Role = null;
                loanRequest.LoanType.LoanRequests = null;

                return Json(loanRequest, JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }




        }

        // GET: LoanRequests/GetUserId
        [HttpGet]
        public string GetUserId(String email)
        {
            return Models_CRUD.GetUserByEmail(email).Id.ToString();
        }

        // POST: LoanRequests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePendingRequests(List<LoanRequest> loanRequests)
        {
            foreach (LoanRequest loanrequest in loanRequests)
            {
                Models_CRUD.UpdateStatusLoanRequest(loanrequest);
            }

            return View(loanRequests);
        }
    }
}
