using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessOperation;
using DataAccess; 

namespace PLF
{
    public partial class Default : System.Web.UI.Page
    {
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Response.Expires = 0;
                SaveUserWorkingEnvironment();
                string deviceScreen = WorkingProfile.ClientUserScreen;
                int xInt = deviceScreen.IndexOf("x");
                string devicewidth = deviceScreen.Substring(0, xInt);

                int dWidth = int.Parse(devicewidth);
  
                DefaultLoad();
            }
        }
        private void DefaultLoad()
        {
            hfPageID.Value = "Default";
            hfUserLoginRole.Value = WorkingProfile.UserRoleLogin;

            hfRunningModel.Value = WebConfigB.RunningModel();
            if (DBConnectionB.CurrentDB != "Live")
            {
                LabelTrain.Text = DBConnectionB.CurrentDB;
                LabelTrain.Visible = true;
            }

            AssembleListItem.SetLists(rblLoginAS, "UserRole", User.Identity.Name,"","");
            AssembleListItem.SetValue(rblLoginAS, WorkingProfile.UserRole);
            try
            {
                LoginUserRole.InnerText = UserProfile.LoginUserName + " as " + rblLoginAS.SelectedItem.Text;
            }

            catch (Exception ex)
            {
                LoginUserRole.InnerText = UserProfile.LoginUserName + " as " + WorkingProfile.UserRole;
            }
            hfCurrentUserRole.Value = WorkingProfile.UserRole;

            GetUserLastWorkingValue();
            
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("Account/Login.aspx");
        }


        protected void rblLoginAS_SelectedIndexChanged(object sender, EventArgs e)
        {
            WorkingProfile.UserRole = rblLoginAS.SelectedValue;
            hfCurrentUserRole.Value = WorkingProfile.UserRole;
            Page.Response.Redirect("Default.aspx");
        }
        private void GetUserLastWorkingValue()
        {
            LabelSchoolYear.Text = UserProfile.CurrentSchoolYear;
            LabelSchoolCode.Text = UserLastWorking.SchoolCode;
            LabelSchool.Text = UserLastWorking.SchoolName;

        }
        private void SaveUserWorkingEnvironment()
        {
            string ScreenSize = WorkingProfile.ClientUserScreen;
            string machine_name = Server.MachineName;
            string browser_type = HttpContext.Current.Request.Browser.Type;
            string browser_version = HttpContext.Current.Request.Browser.Version;

            string lastValue = UserLastWorking.LastValue(User.Identity.Name, "LastValue", WorkingProfile.UserRole, machine_name, ScreenSize, browser_type, browser_version);

        }
    }
}