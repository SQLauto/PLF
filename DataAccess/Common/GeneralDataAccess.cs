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
    public class GeneralDataAccess 
    {
        static string conSTR = DBConnectionHelper.ConnectionSTR();
        public static List<List2Item> GetLists(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var mylist = connection.Query<List2Item>(sp, parameter).ToList();
                //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
                return mylist;
            }
        }
        public static List<FormTitle> GetTitleList(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var mylist = connection.Query<FormTitle>(sp, parameter).ToList();
                return mylist;
            }
        }
      
        public static List<FormContent> GetFormContentList(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                try
                {
                    var mylist = connection.Query<FormContent>(sp, parameter).ToList();
                    return mylist;
                }
                catch (Exception ex)
                {
                    var exm = ex.Message;
                    return null;
                }

            }
        }
        public static List<School> GetSchoolList(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var schoollist = connection.Query<School>(sp, parameter).ToList();
                return schoollist;
            }
        }
        public static List<SiteTeams> GetTeamList(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var mylist = connection.Query<SiteTeams>(sp, parameter).ToList();
                return mylist;
            }
        }

        public static List<T> GetObjectList <T> (string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var mylist = connection.Query<T>(sp, parameter).ToList();
                return mylist;
            }
        }
        public static List<T> GetListofTypeT<T>(string sp, object parameter)
        {// T will be class type. such are School, person, Staff and so on. 
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var mylist = connection.Query<T>(sp, parameter).ToList();
                return mylist;
            }
        }
        public static string TextValue(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var myText = connection.QuerySingle<SingleString>(sp, parameter);
                return myText.MyText;
            }
        }

        public static Boolean BoolValue(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var result = connection.QuerySingle<ReturnValue>(sp, parameter);

                return result.myBool;
            }
        }

        public static DateTime DateValue (string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var result = connection.QuerySingle<ReturnValue>(sp, parameter);

                return result.myDate;
            }

        }
        //public static List<SiteTeams> GetListsold(string operate, string userID, string userRole, string schoolYear, string schoolCode)
        //{
        //    using (IDbConnection connection = new SqlConnection(conSTR))
        //    {
        //        // connection.Query is a Dapper function
        //        //var output = connection.Query<Person>($"select * from People where LastName = '{lastName }'").ToList();
        //        string SP = "dbo.tcdsb_PLF_SchoolSiteTeamNew  @Operate,@UserID, @SchoolYear,@SchoolCode";
        //        ParameterSP1 parameter = new ParameterSP1 { Operate = operate, UserID = userID, UserRole = userRole, SchoolYear = schoolYear, SchoolCode = schoolCode };
        //        var mylist = connection.Query<SiteTeams>(SP, parameter).ToList();
        //        //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
        //        return mylist;
        //    }
        //}
        public static bool IsStringNull(string s)
        {
            return (s == null || s == String.Empty) ? true : false;
        }

     
    }
}
