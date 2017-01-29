using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAP.Services.Definition;
using LAP.Models;
using LAP;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Reflection;
using System.Dynamic;


namespace LoanEngine
{
    public class LoanEngine : ILoanEngine
    {

        public override void AnalyzeApplication(LAP.Models.LoanRequest loanRequest)
        {
            Model1Container db = new Model1Container();

            List<ScoreEngine> listScoreEngines =  Models_CRUD.GetAllScoreEngines();

            String scoreEngineName = listScoreEngines.First().LibName;
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path + "\\" + scoreEngineName;
            path = path.Replace("file:\\", "");

            var DLL = Assembly.LoadFile(path);

            dynamic c = Activator.CreateInstance(DLL.GetExportedTypes().First());
            
            Decimal score = c.GetScore(loanRequest);

            loanRequest.Score = score;

            if (score > 5)
                loanRequest.Status = (int)Status.Engine_Approved;
            else loanRequest.Status = (int)Status.Engine_Denied;
            Models_CRUD.UpdateStatusLoanRequest(loanRequest);                
        }

        public override void SendApprovalEmail(List<LoanRequest> loanRequests)
        {
            string template = Models_CRUD.GetPropertyConfiguration("mailTemplate_Granted").Value;

            //HERE Should be coded how to send one mail per request to the applicant            

        }
        public override void SendDenyEmail(List<LoanRequest> loanRequests)
        {
            string template = Models_CRUD.GetPropertyConfiguration("mailTemplate_Denied").Value;

            //HERE Should be coded how to send one mail per request to the applicant
        }


    }
}
