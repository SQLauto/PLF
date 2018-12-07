using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using ClassLibrary;

namespace DataAccess
{
    public class FormTitle
    {
        static string conSTR = Common.DBConnectionHelper.ConnectionSTR();
        static string sp = "dbo.tcdsb_PLF_GetItemLabelNew";
        public FormTitle()
        { }
        public static string Title(string userID, string itemCode)
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_GetItemLabel";
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[2];
                 SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 0, 30, "@UserID", userID);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 1, 10, "@ItemCode", itemCode);
                return SetSQLParameter.getMyDataValue(sp, myPara);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }
        }
        public static string Title(string operate, string userID, string userRole, string itemCode)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                string SP = sp + " @Operate,@UserID,@UserRole,@ItemCode";
                 ParameterSP0 parameter = new ParameterSP0 { Operate = operate, UserID = userID, UserRole = userRole, ItemCode = itemCode };
                var myTitle = connection.QuerySingle<SingleString>(SP, parameter);
                //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
                return myTitle.MyText ;
            }
        }
        public static string Title(string sp, ParameterSP0 parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
               // string SP = sp + " @Operate,@UserID,@UserRole,@ItemCode";
              //  ParameterSP0 parameter = new ParameterSP0 { Operate = operate, UserID = userID, UserRole = userRole, ItemCode = itemCode };
                var myTitle = connection.QuerySingle<SingleString>(sp, parameter);
                //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
                return myTitle.MyText;
            }
        }

    }
 
}
