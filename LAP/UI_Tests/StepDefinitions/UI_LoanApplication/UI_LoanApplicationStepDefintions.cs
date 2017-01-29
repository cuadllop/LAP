using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow;
using Endjin.SpecFlow.Selenium.Framework.Navigation;
using Specs.Pages;
using Should;

namespace UI_Tests.StepDefinitions.UI_LoanApplication
{
    [Binding]
    class UI_LoanApplicationStepDefintions
    {
        [Given(@"The Loan Type with (basic|advanced) configuration is already configured")]
        public void GivenTheLoanTypeWithBasicConfigurationIsAlreadyConfigured(String type)
        {
            Navigator.Browser.GoToPageByUrl<LoanTypeAdminModel>("http://localhost:19402/LoanTypeAdmin");
            LoanTypeAdminModel loanTypeAdminModel = new LoanTypeAdminModel();
            String loanName = "Loan Type " + type + " " + new Random().Next(1, 20000);
            loanTypeAdminModel.EnterNewLoanName(loanName);
            loanTypeAdminModel.ClickAddNewFieldBtn();
            loanTypeAdminModel.ClickAddNewLoanBtn();
            ScenarioContext.Current.Set(loanName, "loanName");
        }

        [Given(@"I am logged as an applicant into LAP")]
        public void GivenIAmLoggedAsAnApplicantIntoLAP()
        {
            Navigator.Browser.GoToPageByUrl<LoanTypeAdminModel>("http://localhost:19402/LoanRequests");
        }

        [Given(@"I chose the basic configuration template to fill")]
        public void GivenIChoseTheBasicConfigurationTemplateToFill()
        {
            String loanName = ScenarioContext.Current.Get<String>("loanName");

            LoanRequestApplicationModel loanRequestApplicationModel = new LoanRequestApplicationModel();
            loanRequestApplicationModel.SelectCustomerLoanTypeSelectionByOrder(0);
        }

        [When(@"I fill the form and submit to the server with amount (.*) pounds")]
        public void WhenIFillTheFormAndSubmitToTheServerWithAmountPounds(int amount)
        {
            LoanRequestApplicationModel loanRequestApplicationModel = new LoanRequestApplicationModel();
            loanRequestApplicationModel.EnterAmount(amount.ToString());
            
            loanRequestApplicationModel.ClickSubmitRequest();
        }

        [Then(@"request should be tramitted successfully")]
        public void ThenRequestShouldBeTramittedSuccessfully()
        {

        }

        [Then(@"I should see a warning telling that the request was submitted succesfully")]
        public void ThenIShouldSeeAWarningTellingThatTheRequestWasSubmittedSuccesfully()
        {
            Navigator.Browser.Pause(3);
            Navigator.Driver.PageSource.ShouldContain("Your request has been submitted correctly.");
        }

        [Given(@"I filled the form and submit to the server with amount (.*) pounds")]
        public void GivenIFilledTheFormAndSubmitToTheServerWithAmountPounds(int p0)
        {
            LoanRequestApplicationModel loanRequestApplicationModel = new LoanRequestApplicationModel();
            loanRequestApplicationModel.EnterAmount(p0.ToString());
            
            loanRequestApplicationModel.ClickSubmitRequest();
        }

        [Given(@"the Score Unit has already been provided from a third paty Score System a score to the loan application")]
        public void GivenTheScoreUnitHasAlreadyBeenProvidedFromAThirdPatyScoreSystemAScoreToTheLoanApplication()
        {
            Navigator.Browser.GoToPageByUrl<LoanTypeAdminModel>("http://localhost:19402/BackOffice");
            BackOfficeModel backOfficeModel = new BackOfficeModel();
            backOfficeModel.ClickrunLoanEngineAllPendingRequestsBtn();
        }

        [When(@"The loan approval checks and approves all pending requests")]
        public void WhenTheLoanApprovalChecksAndApprovesAllPendingRequests()
        {
            Navigator.Browser.GoToPageByUrl<LoanTypeAdminModel>("http://localhost:19402/BackOffice");
            LoanRequestApprovalModel loanRequestApprovalView = new LoanRequestApprovalModel();
            Navigator.Browser.GoToPageByUrl<LoanRequestApprovalModel>("http://localhost:19402/LoanAdminApproval");
            loanRequestApprovalView.ApproveAllRequests();
            loanRequestApprovalView.ClickSubmitApprovalBtn();
        }


        [Given(@"The loan engine analyzed it")]
        public void GivenTheLoanEngineAnalyzedIt()
        {

        }


        [Then(@"There should not be more pending requests to check")]
        public void ThenThereShouldNotBeMorePendingRequestsToCheck()
        {
            Navigator.Browser.Pause(3);
            Navigator.Driver.PageSource.ShouldContain("All requests have been updated succesfully.");
        }



        [When(@"I check the status of the application several days later")]
        public void WhenICheckTheStatusOfTheApplicationSeveralDaysLater()
        {

        }

        [Then(@"the status should be approved")]
        public void ThenTheStatusShouldBeApproved()
        {

        }


    }
}
