using BusinessOperation;
using ClassLibrary;
using DataAccess;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLF.PLFForm
{
    public partial class SchoolList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _applName = WebConfig.getValuebyKey("ApplicationName");
                hfUserRole.Value = PLF.WorkingProfile.UserRole;

                string sID = Page.Request.QueryString["sID"];
                if (!String.IsNullOrEmpty(sID)) 
                {
                    PLF.WorkingProfile.SchoolCode = sID;
                }
                setPageAttribution();
                BindDDLList();

                BindGridViewData();

                if (PLF.WorkingProfile.UserRole == "Superintendent")
                { ddlSuperarea.Enabled = false;
                    LabelSchool.Visible = false;
                    ddlSchools.Visible = false;
                    ddlSchoolCode.Visible = false;
                }
            }
        }
        private void setPageAttribution()
        {
            hfCategory.Value = "PLF";
            hfPageID.Value = "PLFList";
            hfUserID.Value = User.Identity.Name;
            hfUserLoginRole.Value = WorkingProfile.UserRoleLogin;
            hfRunningModel.Value = WebConfig.RunningModel();
        }
        private void BindDDLList()
        {
            string schoolyear = PLF.WorkingProfile.SchoolYear;
            string schoolcode = PLF.WorkingProfile.SchoolCode;
            string role = PLF.WorkingProfile.UserRole;
            string superArea = PLF.WorkingProfile.UserArea;

            ParameterSP parameter = new ParameterSP { Operate = "SchoolYearbySchool", UserID = User.Identity.Name, UserRole = role, SchoolYear = schoolyear };


            ddlSuperarea.Visible = true;
            AssembleListItem.SetLists(ddlSchoolYear,   parameter, schoolyear);
          //  AssembleListItem.SetValue(ddlSchoolYear, schoolyear);

            if (role == "Principal" || role == "vPrincipal")
            {
                ddlSuperarea.Visible = false;
                superArea = "";
            }
            if (role == "Superintendent")
            {
                ddlSuperarea.Enabled = false;
                //  PLF.WorkingProfile.UserArea = AppraisalProfile.ProfileUser.Area(User.Identity.Name, schoolyear, schoolcode);
            }
            parameter.Operate = "TPASuperArea";
            AssembleListItem.SetLists(ddlSuperarea, parameter, superArea); // "TPASuperArea", User.Identity.Name, role, schoolyear);
           // AssembleListItem.SetValue(ddlSuperarea, superArea);
            
          // AssembleListItem.SetLists2( ddlSchoolCode, ddlSchools, "SchoolListP", User.Identity.Name, role,schoolyear, superArea);
            parameter.Operate = "SchoolListP";
            parameter.SchoolCode = superArea;
            AssembleListItem.SetLists2(ddlSchoolCode, ddlSchools, parameter);

            AssembleListItem.SetValue(ddlSchools, schoolcode);
            AssembleListItem.SetValue(ddlSchoolCode, schoolcode);
        }
        private void BindGridViewData()
        {
            try
            {
                string schoolyear = ddlSchoolYear.SelectedValue;
                string schoolcode = ddlSchools.SelectedValue;
                string schoolarea = ddlSuperarea.SelectedValue;
                //ListGridViewData.BindMyGridView(ref GridView1, "SchoolListbyArea", "DataSet", User.Identity.Name, schoolyear, schoolcode, schoolarea);
                // ListGridViewData.BindMyGridView(ref GridView1, "SchoolListbyArea", "iList", User.Identity.Name, schoolyear, schoolcode, schoolarea);

                School parameter = new School { SchoolYear = schoolyear, SchoolCode = schoolcode, SchoolArea = schoolarea };

            //    PublishandSignOffList.BindGridView(ref GridView1, "SchoolListbyArea", "Dapper", User.Identity.Name, schoolyear, schoolcode, schoolarea);
                PublishandSignOffList.BindGridView(ref GridView1, "SchoolListbyArea", parameter);

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


        protected void ddlSuperarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserLastWorking.UserArea = ddlSuperarea.SelectedValue;
            BindGridViewData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridViewData();
        }
    }

}