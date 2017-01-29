using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAP.Models;

namespace LAP.Services.Definition
{

    //LoanEngine has been designed as an abstract class to make independent the business logic of the engine
    public abstract class ILoanEngine
    {
        /// <summary>
        /// Analyze the request of an applicant, by approving or denying it
        /// </summary>
        /// <param name="LoanRequest">loan request</param>
        /// <returns></returns>
        public abstract void AnalyzeApplication(LoanRequest loanRequest);

        /// <summary>
        /// Send email to each applicant of loan requests notifying that the loan request has been granted.
        /// </summary>
        /// <param name="loanRequests">list of loan requests</param>
        /// <returns></returns>
        public abstract void SendApprovalEmail(List<LoanRequest> loanRequests);

        /// <summary>
        /// Send email to each applicant of loan requests notifying that the loan request has not been granted.
        /// </summary>
        /// <param name="loanRequests">list of loan requests</param>
        /// <returns></returns>        
        public abstract void SendDenyEmail(List<LoanRequest> loanRequests);

    }
}