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

namespace IntTests.StepDefinitions.LoanApplication
{
    [Binding]
    public class LoanApplicationStepDefinitions
    {

        [Given(@"I am logged as an (applicant|underwriter) into LAP")]
        public void GivenIAmLoggedAsAnApplicationIntoLAP(string role)
        {
            User usr = new User();
            usr.Email = "randomuser@email.com";
            usr.Name = "name";

            switch (role)
            {
                case "applicant": usr.Role = Models_CRUD.GetRoleByName("Customer");
                    break;
                case "underwriter": usr.Role = Models_CRUD.GetRoleByName("Underwriter");
                    break;
            }            

            int userId = Models_CRUD.AddUser(usr);

            ScenarioContext.Current.Set<int>(userId, "userId");
        }

        [Given(@"I chose the (.*) template to fill")]
        public void GivenIChoseALoanTemplateToFill(string templateType)
        {
            ScenarioContext.Current.Set(templateType, "templateType");
        }

        [When(@"I fill the form and submit to the server with amount (.*) pounds")]
        [Given(@"I filled the form and submit to the server with amount (.*) pounds")]
        public void WhenIFillTheFormAndSubmitToTheServer(string amount)
        {
            String templateType = ScenarioContext.Current.Get<string>("templateType");
            LoanType loanType =  Models_CRUD.GetLoanTypeByName(templateType);
            
            LoanRequestsController loanApplicationController = new LoanRequestsController();

            loanApplicationController.Index();

            LoanRequest loanRequest = new LoanRequest();
            FormFields ff = new FormFields();
            List<FormFields> ffs = new List<FormFields>();

            loanRequest.LoanType = loanType;
            
            ffs.Add(ff);
            ff.Text = "";
            loanRequest.FormFields = ffs;
            loanRequest.LoanTypeId = loanType.Id;
            loanRequest.User = new User();
            loanRequest.User.Id = ScenarioContext.Current.Get<int>("userId");        
            Random random = new Random();            
            loanRequest.User.Email = "email"+random.Next(1,50000).ToString()+"@mail.com";
            loanRequest.User.Name = "user";
            loanRequest.SubmitDate = DateTime.Now;
            loanRequest.Amount = Convert.ToDecimal(amount);
            JsonResult jsonResult = (JsonResult)loanApplicationController.Create(loanRequest);
            

            ScenarioContext.Current.Set(loanRequest, "loanRequest");
            ScenarioContext.Current.Set(jsonResult, "jsonResult");
            ScenarioContext.Current.Set(loanRequest.User.Id, "userId");
        }

        [Then(@"request should be tramitted successfully")]
        public void ThenRequestShouldBeTramittedSuccessfully()
        {
            int userId = ScenarioContext.Current.Get<int>("userId");
            Models_CRUD.GetLoadRequestByUserIdRequested(userId).ShouldNotBeNull();

            LoanRequestsController loanRequestController = new LoanRequestsController();

            User usr = Models_CRUD.GetUserById(userId);
            loanRequestController.ReturnCustomerRequests(usr.Email).Count().ShouldBeGreaterThan(0);

            loanRequestController.GetUserId(usr.Email).ShouldEqual(usr.Id.ToString());
        }

        [Then(@"I should see a warning telling that the request was submitted succesfully")]
        public void ThenIShouldSeeAWarningTellingThatTheRequestWasSubmittedSuccesfully()
        {
            LoanRequest submittedRequest = ScenarioContext.Current.Get<LoanRequest>("loanRequest");
            ActionResult actionResult = ScenarioContext.Current.Get<ActionResult>("jsonResult");

            JsonResult viewResult = (JsonResult)actionResult;
            LoanRequest loanRequest = (LoanRequest)viewResult.Data;
            
            loanRequest.ShouldNotBeNull();
            loanRequest.Amount.ShouldEqual(submittedRequest.Amount);
            loanRequest.Status.ShouldEqual((int)LAP.Services.Definition.Status.Pending);
        }


        [When(@"I check the status of the application several days later")]
        public void WhenISeeTheStatusOfTheApplicationSeveralDaysLater()
        {
            LoanRequest loanRequest = ScenarioContext.Current.Get<LoanRequest>("loanRequest");            

            LoanRequestsController loanApplicationController = new LoanRequestsController();

            int userId = ScenarioContext.Current.Get<int>("userId");
            User usr = Models_CRUD.GetUserById(userId);
            String loanrequestsSerialized = loanApplicationController.ReturnCustomerRequests(usr.Email);
            List<LoanRequest> loanRequests = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LoanRequest>>(loanrequestsSerialized);

            loanRequest = loanRequests.Find(x => x.Id == loanRequest.Id);
            ScenarioContext.Current.Add("savedLoanRequest", loanRequest);               
        }

        [Then(@"the status should be (.*)")]        
        public void ThenTheStatusShouldBe(String status)
        {            
            LoanRequest loanRequest = ScenarioContext.Current.Get<LoanRequest>("savedLoanRequest");
            loanRequest.ShouldNotBeNull();

            switch (status)
            {
                case "approved": loanRequest.Status.ShouldEqual((int)LAP.Services.Definition.Status.Engine_Approved);
                    break;
                case "denied": loanRequest.Status.ShouldEqual((int)LAP.Services.Definition.Status.Engine_Denied);
                    break;
            }            

        }


    }
}