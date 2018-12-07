using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using ClassLibrary;
using System.Data;

namespace DataAccess
{
    public class FormContentDA
    {
        static string conSTR = Common.DBConnectionHelper.ConnectionSTR();
        public FormContentDA() { }

        public static string TextValue(string sp, ParameterSP0 parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
              //  string SP = sp;
              //  ParameterSP0 parameter = new ParameterSP0 { Operate = operate, UserID = userID, ItemCode = itemCode, SchoolYear = schoolYear, SchoolCode = schoolCode };
                var myText = connection.QuerySingle<SingleString>(sp, parameter);
                return myText.MyText;
            }
        }
        public static string TextValue(string operate, string userID, string userRole, string itemCode, string schoolYear, string schoolCode)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                string sp = "dbo.tcdsb_PLF_FormNew @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@ItemCode";

                ParameterSP0 parameter = new ParameterSP0 { Operate = operate, UserID = userID,   ItemCode = itemCode,SchoolYear=schoolYear,SchoolCode=schoolCode };
                var myText = connection.QuerySingle<SingleString>(sp, parameter);
                return myText.MyText;
            }
        }
        public static string TextValue(string operate, string userID, string userRole, string itemCode, string schoolYear, string schoolCode,string value)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                string sp = "dbo.tcdsb_PLF_FormNew @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@ItemCode,@Value";
                ParameterSP0 parameter = new ParameterSP0 { Operate = operate, UserID = userID,   ItemCode = itemCode, SchoolYear = schoolYear, SchoolCode = schoolCode,Value =value };
                var myText = connection.QuerySingle<SingleString>(sp, parameter);
                return myText.MyText;
            }
        }
        public static string TextValue1(string operate, string userID, string schoolYear, string schoolCode, string itemCode)
        {
            try
            {

                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[5];
                SetupThisParameters(ref myPara, operate, userID, schoolYear, schoolCode);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 4, 10, "@ItemCode", itemCode);
                return SetSQLParameter.getMyDataValue("sp", myPara);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }
        }
        public static string TextValue1(string operate, string userID, string schoolYear, string schoolCode, string itemCode, string value)
        {
            try
            {

                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[6];
                SetupThisParameters(ref myPara, operate, userID, schoolYear, schoolCode);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 4, 10, "@ItemCode", itemCode);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 5, 5000, "@Notes", value);
                return SetSQLParameter.getMyDataValue("sp", myPara);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }

        }
        private static void SetupThisParameters(ref myCommon.MyParameterDB[] myPara, string operate, string userID, string schoolYear, string schoolCode)
        {
            myBaseParameters.SetupBaseParameters(ref myPara, operate, userID, schoolYear, schoolCode);
        }
        private static void SetupThisParameters(ref myCommon.MyParameterDB[] myPara, string operate, string userID, string schoolYear, string schoolCode, string searchby, string searchValue)
        {
            myBaseParameters.SetupBaseParameters(ref myPara, operate, userID, schoolYear, schoolCode);
            SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 4, 30, "@Searchby", searchby);
            SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 5, 30, "@SearchValue", searchValue);

        }

    }
}
