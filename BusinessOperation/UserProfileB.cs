using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessOperation
{
   public  class UserProfileB
    {
         static string SP = "dbo.tcdsb_PLF_UserPermissionControlNew";
       public UserProfileB()
        { }

          public static string Role
        {
            get
            {
                return getProfile("Role");
            }
        }
        public static string Position
        {
            get
            {
                return getProfile("Position");
            }
        }
        public static string LoginUserName
        {
            get
            {
                return getProfile("LoginUserName");
            }
        }
        public static string LoginUserRole
        {
            get
            {
                return getProfile("LoginUserRole");
            }
        }
        public static string CurrentSchoolYear
        {
            get
            {
                return getProfile("CurrentSchoolYear");
            }
        }

        public static string LoginUserEmployeeID
        {
            get
            {
                return getProfile("LoginUserEmployeeID");
            }
        }

        private static string getProfile(string pType)
        {
            try
            {
                ParameterSP parameter = new ParameterSP { Operate = pType, UserID = HttpContext.Current.User.Identity.Name };
                return GeneralDataAccess.TextValue(SP, parameter);
                //  return SignatureProcess.SignoffResult(operate, userID, userRole, schoolYear, schoolCode, actionType, actionDate);
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
 
    }
}
