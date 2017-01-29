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
public class BackOfficeModel : PageModel<BackOfficeView>
{		
   public void ClickrunLoanEngineAllPendingRequestsBtn()
   {
   	this.View.runLoanEngineAllPendingRequestsBtnButton.Click();
   }
   public void ClickremoAllExistingLoanTypeBtn()
   {
   	this.View.remoAllExistingLoanTypeBtnButton.Click();
   }
			
}
public class BackOfficeView : PageView
{
    [FindsBy(How = How.Id, Using = "runLoanEngineAllPendingRequestsBtn")]
   public IWebElement runLoanEngineAllPendingRequestsBtnButton { get; set; }		
   
    [FindsBy(How = How.Id, Using = "remoAllExistingLoanTypeBtn")]
   public IWebElement remoAllExistingLoanTypeBtnButton { get; set; }		
   
	
}
}
