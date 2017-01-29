using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAP.Models;

namespace LAP.Services.Definition
{
    public abstract class IScore
    {
        /// <summary>
        /// Method that handle the logic to the score for a loan request
        /// </summary>
        /// <param name="LoanRequest">loan request</param>
        /// <returns>Returns the score in decimal format</returns>
        abstract public Decimal GetScore(LoanRequest loanRequest);
    }
}
