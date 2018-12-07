using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Common;
using System.Data.SqlClient;
using ClassLibrary;
using Dapper;

namespace DataAccess
{
    public class PLFSiteTeam
    {
        static string sp = "dbo.tcdsb_PLF_SchoolSiteTeamNew  @Operate,@UserID, @SchoolYear,@SchoolCode";
        public PLFSiteTeam()
        { }

        static string conSTR = DBConnectionHelper.ConnectionSTR();
        public static List<SiteTeams> GetLists(string operate, string userID, string userRole, string schoolYear, string schoolCode)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                // connection.Query is a Dapper function
                //var output = connection.Query<Person>($"select * from People where LastName = '{lastName }'").ToList();
                string SP = sp  ;
                 ParameterSP1 parameter = new ParameterSP1 { Operate = operate, UserID = userID, UserRole = userRole, SchoolYear = schoolYear,SchoolCode =schoolCode };
                var mylist = connection.Query<SiteTeams>(SP, parameter).ToList();
                //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
                return mylist;
            }
        }
        public static string Selected(string operate, string userID,  string schoolYear, string schoolCode, string actionType,string employeeID, string selected, string comment)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                string SP = sp + ",@ActionType,@TeacherID,@Checked,@Comments";
                ParameterSP3 parameter = new ParameterSP3 { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode, ActionType=actionType, TeacherID= employeeID, Checked =selected, Comments=comment };
                var myResult = connection.QuerySingle<SingleString>(SP, parameter);
                return myResult.MyText;
            }
        }
        public static string TeamSetup(string operate, string userID, string schoolYear, string schoolCode)
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_SchoolSiteTeam";
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[4];
                SetupThisParameters(ref myPara, operate, userID, schoolYear, schoolCode);
                return SetSQLParameter.getMyDataValue(sp, myPara);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }
        }
        public static string TeamSetup(string operate, string userID, string schoolYear, string schoolCode, string teacherID, string checkvalue, string coments, string action)
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_SchoolSiteTeam";
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[6];
                SetupThisParameters(ref myPara, operate, userID, schoolYear, schoolCode);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 4, 20, "@TeacherID", teacherID);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 5, 10, "@Checked", checkvalue);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 6, 250, "@Comments", coments);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 7, 20, "@Action", action);
                return SetSQLParameter.getMyDataValue(sp, myPara);
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
