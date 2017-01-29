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
public class LoanRequestApplicationModel : PageModel<LoanRequestApplicationView>
{		
   public void EnterCustomerName(string CustomerName)
   {
       this.View.CustomerNameTextbox.SendKeys(CustomerName);
   }

   public void ClickAmountMessage()
   {
       this.View.AmountMessage.Click();
   }
    

   public void ClearCustomerName(string CustomerName)
   {
       this.View.CustomerNameTextbox.Clear();
   }
   public void EnterCustomerEmail(string CustomerEmail)
   {
       this.View.CustomerEmailTextbox.SendKeys(CustomerEmail);
   }

   public void ClearCustomerEmail(string CustomerEmail)
   {
       this.View.CustomerEmailTextbox.Clear();
   }
   public void EnterAmount(string Amount)
   {
       this.View.AmountTextbox.SendKeys(Amount);
       this.View.AmountMessage.Click();
   }

   public void ClearAmount(string Amount)
   {
       this.View.AmountTextbox.Clear();
   }
   public void ClickUpdateSearchForCustomerEmail()
   {
   	this.View.UpdateSearchForCustomerEmailButton.Click();
   }
		public void SelectCustomerLoanTypeSelectionByValue(String value)
		{
			SelectElement select = new SelectElement(this.View.CustomerLoanTypeSelectionSelect);
			select.SelectByValue(value);
		}
		
		public void SelectCustomerLoanTypeSelectionByOrder(int order)
		{
			SelectElement select = new SelectElement(this.View.CustomerLoanTypeSelectionSelect);
			select.SelectByIndex(order);
		}
   public void ClickSubmitRequest()
   {
   	this.View.SubmitRequestButton.Click();
   }
			
}
public class LoanRequestApplicationView : PageView
{
    [FindsBy(How = How.Id, Using = "CustomerName")]
   public IWebElement CustomerNameTextbox { get; set; }		
   
    [FindsBy(How = How.Id, Using = "CustomerEmail")]
   public IWebElement CustomerEmailTextbox { get; set; }		
   
    [FindsBy(How = How.Id, Using = "Amount")]
   public IWebElement AmountTextbox { get; set; }

    [FindsBy(How = How.Id, Using = "amountDiv")]
   public IWebElement AmountMessage { get; set; }		    
   
    [FindsBy(How = How.Id, Using = "UpdateSearchForCustomerEmail")]
   public IWebElement UpdateSearchForCustomerEmailButton { get; set; }		
   
    [FindsBy(How = How.Id, Using = "CustomerLoanTypeSelection")]
   public IWebElement CustomerLoanTypeSelectionSelect { get; set; }		
   
    [FindsBy(How = How.Id, Using = "SubmitRequest")]
   public IWebElement SubmitRequestButton { get; set; }		
   
	
}
}
