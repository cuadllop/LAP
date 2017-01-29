using LAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAP.Controllers
{
    public class LoanTypeAdminController : Controller
    {
        // GET: LoanTypeAdmin
        public ActionResult Index()
        {
            return View();
        }

        // POST: LoanTypeAdmin/Create                
        [HttpPost]
        public JsonResult Create(LAP.Models.LoanType loanType)
        {
            try
            {
                Models_CRUD.AddLoanType(loanType);                
            }
            catch
            {
                return Json("",JsonRequestBehavior.AllowGet);
            }
            return Json(loanType, JsonRequestBehavior.AllowGet);
        }

        // GET: LoanTypeAdmin/GetLoanType/5
        [HttpGet]
        public String GetLoanType(int loanTypeSelected)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(Models_CRUD.GetLoanTypeById(loanTypeSelected));
        }

        // GET: LoanTypeAdmin/GetLoanTypes
        [HttpGet]
        public String GetLoanTypes()
        {
            List<LoanType> loanTypes = Models_CRUD.GetAllLoanType();
            
            List<ViewModelLoanType> vmLoanTypeList = new List<ViewModelLoanType>();
            foreach (LoanType lt in loanTypes)
            {
                vmLoanTypeList.Add(new ViewModelLoanType()
                    {
                        Id = lt.Id,
                        Name = lt.Name                
                    });
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(vmLoanTypeList);
        }

        

    }
}
