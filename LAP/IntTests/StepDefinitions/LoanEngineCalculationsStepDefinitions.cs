using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow;
using LAP.Services;
using LAP.Models;
using Should;
using LAP.Controllers;


namespace IntTests.StepDefinitions
{
    [Binding]
    public class LoanEngineCalculationsStepDefinitions
    {

        [Given(@"the Score Unit has already been provided from a third paty Score System a score to the loan application")]
        public void GivenTheScoreUnitAlreadyHasAlreadyBeenProvidedFromAThirdPatyScoreSystemAScoreToTheLoanApplication()
        {
            
        }

        [When(@"The loan engine analyzes it")]
        [Given(@"The loan engine analyzed it")]
        public void WhenTheLoanEngineAnalyzesItDenyingTheLoan()
        {
            LoanRequest loanRequest = ScenarioContext.Current.Get<LoanRequest>("loanRequest");

            BackOfficeController backOfficeController = new BackOfficeController();
            backOfficeController.Index();
            backOfficeController.RunEngineForAllPendingApps();
        }

        [Then(@"The loan should get (denied|approved) status")]
        [Given(@"The loan got (denied|approved) status")]
        public void ThenTheLoanShouldGetStatus(string decision)
        {
            LoanRequest loanRequest = ScenarioContext.Current.Get<LoanRequest>("loanRequest");
            loanRequest = Models_CRUD.GetLoadRequestById(loanRequest.Id);

            switch (decision)
            {
                case "denied": loanRequest.Status.ShouldEqual((int)LAP.Services.Definition.Status.Engine_Denied);
                    break;
                case "approved": loanRequest.Status.ShouldEqual((int)LAP.Services.Definition.Status.Engine_Approved);
                    break;
            }
        }

        [Then(@"the application must be (approved|denied)")]
        public void ThenTheApplicationMustBeApproved(String finalStatus)
        {
            LoanRequest loanRequest = ScenarioContext.Current.Get<LoanRequest>("loanRequest");
            loanRequest = Models_CRUD.GetLoadRequestById(loanRequest.Id);

            switch (finalStatus)
            { 
                case "denied": loanRequest.Status.ShouldEqual((int)LAP.Services.Definition.Status.Engine_Denied);
                    break;
                case "approved": loanRequest.Status.ShouldEqual((int)LAP.Services.Definition.Status.Engine_Approved);
                    break;        
            }
        }


    }
}