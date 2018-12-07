using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessOperation;
using DataAccess;
namespace PLF.PLFForm
{
    public partial class SchoolTeam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _applName = WebConfig.getValuebyKey("ApplicationName");
          
                string sID = Page.Request.QueryString["sID"];
                if (!String.IsNullOrEmpty(sID))
                {
                    PLF.WorkingProfile.SchoolCode = sID;
                }
                setPageAttribution();
                BindDDLList();

                BindGridViewData();
 
            }
        }
        private void setPageAttribution()
        {
            hfCategory.Value = "PLF";
            hfPageID.Value = "TeamList";
            hfUserID.Value = User.Identity.Name;
            hfUserLoginRole.Value = WorkingProfile.UserRoleLogin;
            hfRunningModel.Value = WebConfig.RunningModel();
            hfUserRole.Value = WorkingProfile.UserRole;
            hfSchoolYear.Value = WorkingProfile.SchoolYear;
            hfSchoolCode.Value = WorkingProfile.SchoolCode;
        }
        private void BindDDLList()
        {
            string schoolyear = PLF.WorkingProfile.SchoolYear;
            string schoolcode = PLF.WorkingProfile.SchoolCode;
            string role = PLF.WorkingProfile.UserRole;
            string superArea = PLF.WorkingProfile.UserArea;

          
            AssembleListItem.SetLists(ddlSchoolYear, "SchoolYearbySchool", User.Identity.Name, role, schoolyear);
            AssembleListItem.SetValue(ddlSchoolYear, schoolyear);

            
             AssembleListItem.SetLists2(ddlSchoolCode, ddlSchool, "SchoolListP", User.Identity.Name, role, schoolyear, superArea);

            AssembleListItem.SetValue(ddlSchool, schoolcode);
            AssembleListItem.SetValue(ddlSchoolCode, schoolcode);
        }
        private void BindGridViewData()
        {
            try
            {
                string schoolyear = ddlSchoolYear.SelectedValue;
                string schoolcode = ddlSchool.SelectedValue;
                //ListGridViewData.BindMyGridView(ref GridView1, "SchoolListbyArea", "DataSet", User.Identity.Name, schoolyear, schoolcode, schoolarea);
                // ListGridViewData.BindMyGridView(ref GridView1, "SchoolListbyArea", "iList", User.Identity.Name, schoolyear, schoolcode, schoolarea);
                SiteTeamSetup.BindGridView(ref GridView1, "SchoolTeamList", "Dapper", User.Identity.Name, schoolyear, schoolcode );

            }
            catch (Exception ex)
            {
                var em = ex.Message;
            }

        }

        protected void ddlSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserLastWorking.SchoolYear = ddlSchoolYear.SelectedValue;
            BindGridViewData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridViewData();
        }
    }
}