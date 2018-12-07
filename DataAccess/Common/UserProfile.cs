
using System;
using System.Data;
using System.Web;

namespace DataAccess
{

    public class UserProfile
    {
        public UserProfile()
        { }
        static string SP = "dbo.tcdsb_PLF_UserPermissionControl";
   
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
            myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[2];
            SetupThisParameters(ref myPara, pType, HttpContext.Current.User.Identity.Name);
            return SetSQLParameter.getMyDataValue(SP, myPara);
        }
 
        private static void SetupThisParameters(ref myCommon.MyParameterDB[] myPara , string operate,string userID)
        {
           SetSQLParameter.setParameterArray(myPara, DbType.String, 0, 30, "@UserID", userID);
           SetSQLParameter.setParameterArray(myPara, DbType.String, 1, 30, "@Type", operate  );
        }
        public static string UserLoginRole(string userId)
        {
            myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[2];
            SetupThisParameters(ref myPara, "Role", userId);
            return SetSQLParameter.getMyDataValue(SP, myPara);
        }
     }
}


 