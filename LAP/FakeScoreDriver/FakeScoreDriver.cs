using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAP.Models;
using LAP.Services.Definition;

namespace FakeScoreDriver
{
    public class FakeScoreDriver : IScore
    {

        // THis Score Driver takes the risk as a negative value
        // It gives positive values for low quantity of Amount
        // It does not take into consideration the rest of optional parameters
        override public Decimal GetScore(LoanRequest loanRequest)
        {
            Decimal score = (loanRequest.Amount < 1000) ? 10 : 4;
            return score;
        }
    }
}
