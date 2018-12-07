using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess 
{
   public class UserLastWorking
    {
        static string SP = "dbo.tcdsb_PLF_UserWorkingTrack";
       public UserLastWorking()
        { }
        public static string EmployeeID
        {
            get
            {
                return LastValue("WorkingUser" );
            }
            set
            {
                LastValue("WorkingUser", value);  
            }
        }
        public static string SchoolYear
        {
            get
            {
                return LastValue("WorkYear");
            }
            set
            {
                LastValue("WorkYear", value);
            }
        }
        public static string OpenSchoolYear
        {
            get
            {
                return LastValue("OpenSchoolYear");
            }
            set
            {
                LastValue("OpenSchoolYear", value);
            }
        }
        public static string SchoolCode
        {
            get
            {
                return LastValue("WorkSchool");
            }
            set
            {
                LastValue("WorkSchool", value);
            }
        }
        public static string SchoolName
        {
            get
            {
                return LastValue("SchoolName");
            }
        }
        public static string SchoolNameB
        {
            get
            {
                return LastValue("SchoolNameB");
            }

        }
        public static string SchoolPrincipal
        {
            get
            {
                return LastValue("SchoolPrincipal");
            }

        }
        public static string CurrentSchoolYear
        {
            get
            {
                return LastValue("CurrentSchoolYear");
            }

        }
        public static string UserArea
        {
            get
            {
                return LastValue("UserArea");
            }
            set
            {
                LastValue("UserArea", value);
            }
        }
        public static string UserAreaSuperintendent
        {
            get
            {
                return LastValue("AreaSuperintendent");
            }
            set
            {
                LastValue("AreaSuperintendent", value);
            }
        }
        public static string ClientScreen
        {
            get
            {
                return LastValue("ClientScreen");
            }

        }
        private static string LastValue(string operate )
        {
            try
            {              
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[2];
                myBaseParameters.SetupBaseParameters(ref myPara, operate, HttpContext.Current.User.Identity.Name);
               return   SetSQLParameter.getMyDataValue(SP, myPara);
            }
            catch (Exception ex)
            { var em = ex.Message;
                return "";
            }
            finally
            { }
        }
        private static void LastValue(string operate,   string value)
        {
            try
            {
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[3];
                myBaseParameters.SetupBaseParameters(ref myPara, operate, HttpContext.Current.User.Identity.Name);
                SetSQLParameter.setParameterArray(myPara,  DbType.String, 2, 50, "@Value", value);
                SetSQLParameter.getMyDataValue(SP, myPara);
            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }
        public static string LastValue(string userId, string operate, string value, string machin_name, string sccreen, string browser_type, string browser_version)
        {
            try
            {
                string SP = "dbo.tcdsb_PLF_UserWorkingTrack";
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[7];
                SetupBaseParameters(ref myPara, "LastValue", userId);
                SetSQLParameter.setParameterArray(myPara, DbType.String, 2, 50, "@Value", value);
                SetSQLParameter.setParameterArray(myPara, DbType.String, 3, 30, "@MachinName", machin_name);
                SetSQLParameter.setParameterArray(myPara, DbType.String, 4, 30, "@ScreenSize", sccreen);
                SetSQLParameter.setParameterArray(myPara, DbType.String, 5, 30, "@BrowerType", browser_type);
                SetSQLParameter.setParameterArray(myPara, DbType.String, 6, 30, "@BrowerVersion", browser_version);
                return SetSQLParameter.getMyDataValue(SP, myPara);
            }
            catch (Exception ex)
            {
                string myEx = ex.Message;
                return null;
            }
            finally
            { }
        }
        private static void SetupBaseParameters(ref myCommon.MyParameterDB[] myPara, string operate, string userID)
        {
            SetSQLParameter.setParameterArray(myPara, DbType.String, 0, 30, "@Operate", operate);
            SetSQLParameter.setParameterArray(myPara, DbType.String, 1, 30, "@UserID", userID);
        }
    }
}
