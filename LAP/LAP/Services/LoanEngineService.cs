using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAP.Models;
using System.Reflection;
using System.IO;
using LAP.Services.Definition;

namespace LAP.Services
{
    public class LoanEngineService
    {
        public void AnalyzeApplication(LoanRequest loanRequest)
        {                
           //Obtaining the definition of the engine configured in DDBB
           String LoanEngineLibDLL = Models_CRUD.GetPropertyConfiguration("libraryName_LoanEngine").Value;

           String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
           path = path +"\\"+ LoanEngineLibDLL;
           path = path.Replace("file:\\", "");

           var DLL = Assembly.LoadFile(path);

           //Calling Loan Engine to update the loan request status 
           ILoanEngine c = (ILoanEngine)Activator.CreateInstance(DLL.GetExportedTypes().First());
           c.AnalyzeApplication(loanRequest);
        }
    }
}