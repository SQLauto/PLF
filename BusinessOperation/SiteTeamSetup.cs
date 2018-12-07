using ClassLibrary;
using DataAccess;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessOperation
{
    public class SiteTeamSetup
    {
        static string sp = "dbo.tcdsb_PLF_SchoolSiteTeamNew @Operate,@UserID, @SchoolYear,@SchoolCode";
        public static void BindGridView(ref GridView myGridView, string listPage, string method, string userID, string schoolYear, string schoolCode)
        {
            try
            {
                ParameterSP parameter = new ParameterSP { Operate = method, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode };
             //   List<SiteTeams> teams = GeneralDataAccess.GetTeamList(sp, parameter);
                List<SiteTeams> teams = GeneralDataAccess.GetObjectList<SiteTeams>(sp, parameter);

                myGridView.DataSource = teams;
                myGridView.DataBind();

            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }

        public static string TeamMemberSelect(string operate, string userID, string schoolYear, string schoolCode, string actionType, string employeeID, string selected, string comment)
        {
             string  sp1 =  sp + ",@ActionType,@TeacherID,@Checked,@Comments";
            ParameterSP3 parameter = new ParameterSP3 { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode, ActionType = actionType, TeacherID = employeeID, Checked = selected, Comments = comment };
            return GeneralDataAccess.TextValue(sp1, parameter);
            // return PLFSiteTeam.Selected(operate, userID, schoolCode, schoolYear, actionType, employeeID, selected, comment);
        }
    }
}
