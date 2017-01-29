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

namespace IntTests.StepDefinitions.LoanTypeAdministration
{
    [Binding]
    public class LoanTypeAdministrationStepDefinitions
    {

        [Given(@"I am logged as a System Administrator of LAP")]
        public void GivenIAmLoggedAsASystemAdministratorOfLAP()
        {

        }

        [When(@"I enter a new Loan Type with (basic configuration|advanced configuration)")]
        [Given(@"The Loan Type with (basic configuration|advanced configuration) is already configured")]
        public void WhenIEnterANewLoanTypeWithBasicConfiguration(string confType)
        {
            ActionResult actionResult; 

            LoanTypeAdminController loanTypeAdminController = new LoanTypeAdminController();

            loanTypeAdminController.Index();
            
            LoanType basicLoanType = new LoanType();
            if (confType.Contains("basic"))
                basicLoanType.AdditionalFields = @"";
            else
                basicLoanType.AdditionalFields = @"{[{""name"": ""Morgue Tax"", ""type"":""textbox""}]}";
            basicLoanType.LoanRequests = new List<LoanRequest>();

            int numInstances = Models_CRUD.GetAllLoanType().Where(x=>x.Name.StartsWith(confType)).Count();
            if (numInstances == 0)
                basicLoanType.Name = confType;
            else basicLoanType.Name = String.Format("{0} {1}", confType ,numInstances.ToString());


            actionResult = (JsonResult)loanTypeAdminController.Create(basicLoanType);
            ScenarioContext.Current.Add("actionResult", actionResult);

            ScenarioContext.Current.Add("loanTypeName", basicLoanType.Name);                     
        }
      
        [Then(@"the loan should be saved properly")]
        public void ThenTheLoanShouldBeSavedProperly()
        {
            string loanTypeName = ScenarioContext.Current.Get<string>("loanTypeName");
            Models_CRUD.GetLoanTypeByName(loanTypeName).Name.ShouldEqual(loanTypeName);

        }

        [Then(@"I should see a warning telling that the loan type was saved")]
        public void ThenIShouldSeeAWarningTellingThatTheLoanTypeWasSaved()
        {
            String loanTypeName = ScenarioContext.Current.Get<String>("loanTypeName");

            JsonResult actionResult = (JsonResult)ScenarioContext.Current.Get<ActionResult>("actionResult");
            LoanType loanType = (LoanType)actionResult.Data;
            loanType.ShouldNotBeNull();
            loanType.Name.ShouldEqual(loanTypeName);

            LoanTypeAdminController loanTypeAdminController = new LoanTypeAdminController();
            
            LoanType ltObtained = Newtonsoft.Json.JsonConvert.DeserializeObject<LoanType>(loanTypeAdminController.GetLoanType(loanType.Id));
            ltObtained.Name.ShouldEqual(loanTypeName);

            string ltsObtainedSerialized = loanTypeAdminController.GetLoanTypes();
            List<ViewModelLoanType> vmLoanTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ViewModelLoanType>>(ltsObtainedSerialized);
            vmLoanTypes.Any(x => x.Id == loanType.Id).ShouldBeTrue();
        }


    }
}