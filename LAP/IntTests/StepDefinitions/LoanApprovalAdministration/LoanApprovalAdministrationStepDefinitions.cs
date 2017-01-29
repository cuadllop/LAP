using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow;
using LAP.Controllers;
using LAP.Models;
using System.Web.Mvc;
using Should;

namespace IntTests.StepDefinitions.LoanApprovalAdministration
{
    [Binding]
    public class LoanApprovalAdministrationStepDefinitions
    {

        [When(@"I (approve|deny) all the requests")]
        public void WhenIApproveTheRequest(string finalStatus)
        {
            LoanRequestsController loanApplicationController = new LoanRequestsController();
            ActionResult ar = loanApplicationController.ReturnPendingRequests();
            ViewResult viewresult = (ViewResult)ar;

            List<LoanRequest> loanRequests = (List<LoanRequest>)viewresult.Model;

            foreach (LoanRequest loanRequest in loanRequests)
            { 
                switch (finalStatus)
                {
                    case "approve": loanRequest.Status = (int)LAP.Services.Definition.Status.Underwriter_Approved;
                        break;
                    case "deny": loanRequest.Status = (int)LAP.Services.Definition.Status.Engine_Denied;
                        break;
                }                
            }

            //getting the new ViewResult with the info of updated Loan Requests
            LoanAdminApprovalController loanAdminApprovalController = new LoanAdminApprovalController();

            JsonResult jsonResult = loanAdminApprovalController.UpdateApprovalProcess(loanRequests);            
            loanRequests = (List<LoanRequest>)viewresult.Model;

            ScenarioContext.Current.Set(jsonResult, "jsonResult");
            ScenarioContext.Current.Set(loanRequests,"loneRequests");
        }

        [Then(@"The Loan Engine must send a mail to the customer telling the request was (denied|approved)")]
        public void ThenTheLoanEngineMustSendAMailToTheCustomerTellingTheRequestWasDenied(string decision)
        {
            List<LoanRequest> loanRequests= ScenarioContext.Current.Get<List<LoanRequest>>("loneRequests");

            LoanEngine.LoanEngine loanEngine = new LoanEngine.LoanEngine();

            switch (decision)
            { 
                case "denied": loanEngine.SendDenyEmail(loanRequests.Where(x=>x.Status==(int)LAP.Services.Definition.Status.Underwriter_Denied).ToList());
                    break;
                case "approved": loanEngine.SendApprovalEmail(loanRequests.Where(x => x.Status == (int)LAP.Services.Definition.Status.Underwriter_Denied).ToList());
                    break;
            }
        }

        [Given(@"the Score Unit already has already been provided from a third paty Score System a score to the loan application")]
        public void GivenTheScoreUnitAlreadyHasAlreadyBeenProvidedFromAThirdPatyScoreSystemAScoreToTheLoanApplication()
        {
            
        }


    }
}