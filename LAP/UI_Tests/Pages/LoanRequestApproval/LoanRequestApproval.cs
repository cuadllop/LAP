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
public class LoanRequestApprovalModel : PageModel<LoanRequestApprovalView>
{		
   public void ClickSubmitApprovalBtn()
   {
   	this.View.SubmitApprovalBtnButton.Click();
   }


   public void ApproveAllRequests()
   {
       var elements = Navigator.Driver.FindElements(By.Name("selectStatus"));
       int i = 0;
       foreach (IWebElement e in elements)
       {
           Navigator.Driver.FindElement(By.Id("select_" + i))
                .FindElement(By.CssSelector("option[value='3']")).Click();
           i++;
       }

   }
}
public class LoanRequestApprovalView : PageView
{
    [FindsBy(How = How.Id, Using = "SubmitApprovalBtn")]
   public IWebElement SubmitApprovalBtnButton { get; set; }		
   
	
}
}
