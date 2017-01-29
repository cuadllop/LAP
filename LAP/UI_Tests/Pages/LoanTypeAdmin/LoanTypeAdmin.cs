using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endjin.SpecFlow.Selenium.Framework.Models;
using Endjin.SpecFlow.Selenium.Framework.Views;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Endjin.SpecFlow.Selenium.Framework.Navigation;
namespace Specs.Pages
{
public class LoanTypeAdminModel : PageModel<LoanTypeAdminView>
{		
   public void EnterNewLoanName(string NewLoanName)
   {
       this.View.NewLoanNameTextbox.SendKeys(NewLoanName);
   }

   public void ClearNewLoanName(string NewLoanName)
   {
       this.View.NewLoanNameTextbox.Clear();
   }
   public void ClickAddNewFieldBtn()
   {
   	this.View.AddNewFieldBtnButton.Click();
   }
   public void ClickAddNewLoanBtn()
   {
   	this.View.AddNewLoanBtnButton.Click();
   }
			
}
public class LoanTypeAdminView : PageView
{
    [FindsBy(How = How.Id, Using = "NewLoanName")]
   public IWebElement NewLoanNameTextbox { get; set; }		
   
    [FindsBy(How = How.Id, Using = "AddNewFieldBtn")]
   public IWebElement AddNewFieldBtnButton { get; set; }		
   
    [FindsBy(How = How.Id, Using = "AddNewLoanBtn")]
   public IWebElement AddNewLoanBtnButton { get; set; }		
   
	
}
}
