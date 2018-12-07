using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;
using Dapper;

namespace DataAccess
{
    public class SignatureProcess
    {
        static string conSTR = Common.DBConnectionHelper.ConnectionSTR();
        static string sp = "dbo.tcdsb_PLF_Form_SignOffNew @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@ActionType";
        public SignatureProcess()
        { }
        public static string SignoffResult(string operate, string userID, string userRole, string schoolYear, string schoolCode, string actionType)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                string SP = sp;// + " @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@ActionType";
                ParameterSP1 parameter = new ParameterSP1 { Operate = operate, UserID = userID, UserRole = userRole, SchoolYear = schoolYear, SchoolCode = schoolCode, ActionType = actionType };
                var myResult = connection.QuerySingle<SingleString>(SP, parameter);
                //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
                return myResult.MyText;
            }
        }
        public static string SignoffResult(string operate, string userID, string userRole, string schoolYear, string schoolCode, string actionType, string actionDate)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                string SP = sp + ",@ActionDate";
                ParameterSP1 parameter = new ParameterSP1 { Operate = operate, UserID = userID, UserRole = userRole, SchoolYear = schoolYear, SchoolCode = schoolCode, ActionType = actionType, ActionDate = actionDate };
                var myResult = connection.QuerySingle<SingleString>(SP, parameter);
                //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
                return myResult.MyText;
            }
        }
        
    }
}
