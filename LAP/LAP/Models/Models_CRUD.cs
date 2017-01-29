using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAP.Models;

namespace LAP.Models
{
    public static class Models_CRUD
    {
        #region "LoanType"
        public static LoanType GetLoanTypeByName(string name)
        {
            Model1Container context = new Model1Container();
            return context.LoanTypes.FirstOrDefault(x => x.Name == name);         
        }

        public static LoanType GetLoanTypeById(int id)
        {
            Model1Container context = new Model1Container();
            return context.LoanTypes.FirstOrDefault(x => x.Id == id);         
        }

        public static void RemoveAllLoanTypes_WithoutLoanRequests()
        {
            Model1Container context = new Model1Container();
            var listLoanTypes = context.LoanTypes.Where(x => x.LoanRequests.Count() == 0);
            foreach (LoanType lt in listLoanTypes)
            {
                context.LoanTypes.Remove(lt);
            }
            context.SaveChanges();
        }
        

        public static List<LoanType> GetAllLoanType()
        {
            Model1Container context = new Model1Container();           
            return context.LoanTypes.ToList();
        }

        internal static void AddLoanType(LoanType loanType)
        {
            Model1Container context = new Model1Container();
            context.LoanTypes.Add(loanType);
            context.SaveChanges();
        }

        #endregion

        #region "LoanRequest"
        public static LoanRequest GetLoadRequestById(int loanRequestId)
        {
            Model1Container context = new Model1Container();
            return context.LoanRequests.FirstOrDefault(x => x.Id == loanRequestId);
        }

        public static void UpdateStatusLoanRequest(LoanRequest loanRequest)
        {
            Model1Container context = new Model1Container();
            LoanRequest lr = context.LoanRequests.FirstOrDefault(x => x.Id == loanRequest.Id);
            lr.Status = loanRequest.Status;
            context.SaveChanges();
        }

        public static LoanRequest GetLoadRequestByUserIdRequested(int userId)
        {
            Model1Container context = new Model1Container();
            return context.LoanRequests.FirstOrDefault(x => x.User.Id == userId);
        }

        public static List<LoanRequest> GetAllLoanRequestsByUserId(int userId)
        {
            Model1Container context = new Model1Container();
            return context.LoanRequests.Where(x => x.User.Id == userId).ToList();
        }

        internal static List<LoanRequest> GetAllRequestsConfirmedByEngine()
        {
            Model1Container context = new Model1Container();
            List<LoanRequest> loanRequests = context.LoanRequests.Where(FindEngineTypeStatusLoan).ToList();
            return loanRequests;
        }

        internal static List<LoanRequest> GetAllPendingLoanRequests()
        {
            Model1Container context = new Model1Container();
            List<LoanRequest> loanRequests = context.LoanRequests.Where(FindPendingStatusLoan).ToList();
            return loanRequests;
        }

        private static bool FindEngineTypeStatusLoan(LoanRequest lr)
        {
            bool EngineApprovedLoans = lr.Status==(int)LAP.Services.Definition.Status.Engine_Approved;
            bool EngineDeniedLoans = lr.Status == (int)LAP.Services.Definition.Status.Engine_Denied;

            return EngineApprovedLoans || EngineDeniedLoans;
        }

        private static bool FindPendingStatusLoan(LoanRequest lr)
        {
            bool PendingLoans = lr.Status == (int)LAP.Services.Definition.Status.Pending;

            return PendingLoans ;
        }

        #endregion
        #region "User"
        public static int AddUser(User usr)
        {
            Model1Container context = new Model1Container();
            usr.Role = context.Roles.First(x => x.Id == usr.Role.Id);
            context.Users.Add(usr);
            
            context.SaveChanges();

            return usr.Id;
        }


        public static User GetUserById(int id)
        {

            Model1Container context = new Model1Container();
            User usr = context.Users.FirstOrDefault(x => x.Id == id);
            return usr;
        }

        public static User GetUserByEmail(string email)
        {

            Model1Container context = new Model1Container();
            User usr = context.Users.FirstOrDefault(x => x.Email == email);
            return usr;
        }

        #endregion

        #region "Role"

        public static Role GetRoleByName(string name)
        {
            Model1Container context = new Model1Container();
            return context.Roles.FirstOrDefault(x => x.Name == name);
        }

        public static int AddRole(Role role)
        {
            Model1Container context = new Model1Container();
            context.Roles.Add(role);
            context.SaveChanges();

            return role.Id;
        }
        #endregion

        #region "Score"
        public static List<ScoreEngine> GetAllScoreEngines()
        {
            Model1Container context = new Model1Container();
            return context.ScoreEngines.ToList();
        }

        public static object GetScoreDriverByName(string scoreDriverName)
        {
            Model1Container context = new Model1Container();
            ScoreEngine scoreEngine = context.ScoreEngines.FirstOrDefault(x => x.Name == scoreDriverName);

            return scoreEngine;
        }

        public static int AddScoreDriver(ScoreEngine scoreEngine)
        {
            Model1Container context = new Model1Container();
            context.ScoreEngines.Add(scoreEngine);
            context.SaveChanges();
            return scoreEngine.Id;

        }
        #endregion

        #region "PropertyConfiguration"
        public static SystemConfiguration GetPropertyConfiguration(string propertyName)
        {
            Model1Container context = new Model1Container();
            SystemConfiguration property = context.SystemConfigurations.FirstOrDefault(x=>x.Name==propertyName);           

            return property;
        }

        public static string SetPropertyConfiguration(string propertyName, string propertyValue)
        {
            Model1Container context = new Model1Container();

            SystemConfiguration property = new SystemConfiguration();
            property.Name = propertyName;
            property.Value = propertyValue;

            context.SystemConfigurations.Add(property);
             
            context.SaveChanges();

            return property.Value;
        }

        #endregion


    }
}