using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using LAP.Models;
using DbUp;
using System.Reflection;
using System.Configuration;
using System.Data.SqlClient;
using LAP.Controllers;

namespace IntTests
{
    [Binding]
    public sealed class Hooks
    {

        [BeforeScenario]
        public void BeforeScenario()
        {            
            this.FillDB_RequiredInfo();

            HomeController homeController = new HomeController();
            homeController.Index();
        }
   
        private void FillDB_RequiredInfo()
        {
            if (Models_CRUD.GetRoleByName("Customer") == null)
            {
                Role customerRole = new Role();
                customerRole.Name = "Customer";
                Models_CRUD.AddRole(customerRole);
            }

            if (Models_CRUD.GetRoleByName("Underwriter") == null)
            {
                Role customerRole = new Role();
                customerRole.Name = "Underwriter";
                Models_CRUD.AddRole(customerRole);           
            }
                    
            if (Models_CRUD.GetPropertyConfiguration("libraryName_LoanEngine") == null)
            {
                Models_CRUD.SetPropertyConfiguration("libraryName_LoanEngine", "LoanEngine.dll");
            }

            if (Models_CRUD.GetPropertyConfiguration("mailTemplate_Denied") == null)
            {
                Models_CRUD.SetPropertyConfiguration("mailTemplate_Denied", "XXXXX");
            }

            if (Models_CRUD.GetPropertyConfiguration("mailTemplate_Granted") == null)
            {
                Models_CRUD.SetPropertyConfiguration("mailTemplate_Granted", "YYYYY");
            }

            if (Models_CRUD.GetScoreDriverByName("FakeScoreDriver") == null)
            {
                ScoreEngine scoreEngine = new ScoreEngine();
                scoreEngine.LibName = "FakeScoreDriver.dll";
                scoreEngine.Name = "FakeScoreDriver";

                Models_CRUD.AddScoreDriver(scoreEngine);
            }
        }

        [AfterScenario]        
        public void AfterScenario()
        {            
         BackOfficeController backofficeController = new BackOfficeController();
         backofficeController.RemoveAllLoanTypes();
        }
   
    }

}
