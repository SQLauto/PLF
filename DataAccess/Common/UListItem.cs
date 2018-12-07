using ClassLibrary;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Common
{
    public static class UListItem
    {
        static string  conSTR = DBConnectionHelper.ConnectionSTR();
        public static List<List2Item> GetLists(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                  var mylist = connection.Query<List2Item>(sp,  parameter).ToList();
                //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
                return mylist;
            }
        }
        public static List<List2Item> GetLists(string operate, string userID, string userRole, string schoolYear)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                // connection.Query is a Dapper function
                //var output = connection.Query<Person>($"select * from People where LastName = '{lastName }'").ToList();
                string SP = "dbo.tcdsb_PLF_ListDDL2New @Operate,@UserID,@UserRole,@SchoolYear";
               // ParameterSP parameter = new ParameterSP { Operate = operate, UserID = userID };
                var mylist = connection.Query<List2Item>(SP, (new ParameterSP1 { Operate = operate, UserID = userID, UserRole =userRole,SchoolYear=schoolYear })).ToList();
               //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
                return mylist;
            }
        }
        public static List<List2Item> GetLists(string operate, string userID, string userRole,string schoolYear, string schoolCode)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                string SP = "dbo.tcdsb_PLF_ListSchoolsNew @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode";
                ParameterSP2 parameter = new ParameterSP2 { Operate = operate, UserID = userID, UserRole = userRole , SchoolYear = schoolYear, SchoolCode = schoolCode};
                var mylist = connection.Query<List2Item>(SP, parameter).ToList();
                return mylist;
            }
        }
    }
}
