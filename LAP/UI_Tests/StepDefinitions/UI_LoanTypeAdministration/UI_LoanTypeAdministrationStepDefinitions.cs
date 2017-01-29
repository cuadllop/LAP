using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow;
using Endjin.SpecFlow.Selenium.Framework.Navigation;
using Specs.Pages;
using Should;

namespace UI_Tests.StepDefinitions.UI_LoanTypeAdministration
{
    [Binding]
    class UI_LoanTypeAdministrationStepDefinitions
    {

        [Given(@"I am logged as a System Administrator of LAP")]
        public void GivenIAmLoggedAsASystemAdministratorOfLAP()
        {
            Navigator.Browser.GoToPageByUrl<LoanTypeAdminModel>("http://localhost:19402/LoanTypeAdmin");
        }

        [Then(@"the loan should be saved properly")]
        public void ThenTheLoanShouldBeSavedProperly()
        {

        }

        [Then(@"I should see a warning telling that the loan type was saved")]
        public void ThenIShouldSeeAWarningTellingThatTheLoanTypeWasSaved()
        {
            Navigator.Browser.Pause(3);
            Navigator.Driver.PageSource.ShouldContain("The loan type was saved correctly");
        }

        [When(@"I enter a new Loan Type with (Basic|Advanced) configuration")]
        public void WhenIEnterANewLoanTypeWithAdvancedConfiguration(String type)
        {
            LoanTypeAdminModel loanTypeAdminModel = new LoanTypeAdminModel();
            String loanName = "Loan Type "+type+" " + new Random().Next(1, 20000);
            loanTypeAdminModel.EnterNewLoanName(loanName);
            loanTypeAdminModel.ClickAddNewFieldBtn();
            loanTypeAdminModel.ClickAddNewLoanBtn();
            ScenarioContext.Current.Set(loanName, "loanName");
        }


    }
}
