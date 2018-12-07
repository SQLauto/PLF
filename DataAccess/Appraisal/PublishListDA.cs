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
    public static class PublishListDA
    {
        static string  conSTR = DBConnectionHelper.ConnectionSTR();
        public static List<School> GetSchoolList(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                  var schoollist = connection.Query<School>(sp, parameter).ToList();
                return schoollist;
            }  
        }
        public static List<School> GetSchoolHistroy(string operate, string userID, string userRole, string schoolYear, string schoolCode)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                 string SP = "dbo.tcdsb_PLF_SchoolHistoryNew @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode";
                ParameterSP1 parameter = new ParameterSP1 { Operate = operate, UserID = userID, UserRole=userRole ,SchoolYear = schoolYear, SchoolCode = schoolCode};
                var schoollist = connection.Query<School>(SP, parameter).ToList();
                 return schoollist;
            }
        }
        public static List<School> GetAreaSchools(string operate, string userID, string userRole, string schoolYear, string schoolCode, string schoolArea)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                 string SP = "dbo.tcdsb_PLF_AreaSchoolList @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@SchoolArea";
                ParameterSP2 parameter = new ParameterSP2 { Operate = operate, UserID = userID, UserRole = userRole, SchoolYear = schoolYear, SchoolCode = schoolCode, SchoolArea = schoolArea };
                var schoollist = connection.Query<School>(SP, parameter).ToList();
                 return schoollist;
            }
        }
    }
}
