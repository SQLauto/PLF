using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using System.Web.UI.HtmlControls;
using BusinessOperation;
using ClassLibrary;
using System.Threading.Tasks;

namespace PLF.PLFForm
{
    public partial class LearningForm : System.Web.UI.Page
    {
        string schoolYear;
        string schoolCode;
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Response.Expires = 0;
                Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                string yID = Request.QueryString["yID"];

                if (!String.IsNullOrEmpty(yID))
                {
                    WorkingProfile.SchoolYear = Page.Request.QueryString["yID"];
                    WorkingProfile.SchoolCode = Page.Request.QueryString["sID"];
                    WorkingProfile.SchoolName = UserLastWorking.SchoolName;
                    WorkingProfile.SchoolNameB = UserLastWorking.SchoolNameB;
                    WorkingProfile.SchoolPrincipal = UserLastWorking.SchoolPrincipal;
                    schoolYear = Page.Request.QueryString["yID"];
                    schoolCode = Page.Request.QueryString["sID"];

                }
                Assemblies_Title();
                // LoadingPageDataAll();
                await LoadingPageDataAllAsync();
            }
        }
        private void Assemblies_Title()
        {
            string userID = User.Identity.Name;
            LabelSchoolyear.Text = DateFC.SchoolYearFrom("-", schoolYear);
            LabelSchool.Text = WorkingProfile.SchoolName;
            LabelPrincipal.Text = WorkingProfile.SchoolPrincipal;
            LabelSuperintendent.Text = WorkingProfile.UserAreaSuperintendent;
            hfSchoolcode.Value = schoolCode;
            hfSchoolyear.Value = schoolYear;
            hfUserRole.Value = WorkingProfile.UserRole;
            hfUserID.Value = User.Identity.Name;
            hfSignOff.Value = SignOff.Signature2("Result", userID, schoolYear, schoolCode, "School");
            hfSignOffSO.Value = SignOff.Signature2("Result", userID, schoolYear, schoolCode, "SO");
            hfPublish.Value = SignOff.Signature2("Result", userID, schoolYear, schoolCode, "Publish");
            hfComplete.Value = SignOff.Signature2("Result", userID, schoolYear, schoolCode, "Complete");

        }
        private void LoadingPageDataAll()
        {
            //  Loading_Title();
            //  Loading_Data();
            FormData.AssembliesPLFForm(Page, User.Identity.Name, schoolYear, schoolCode);
        }
        private async Task LoadingPageDataAllAsync()
        {


            await Task.Run(() => FormData.AssembliesPLFForm(Page, User.Identity.Name, schoolYear, schoolCode));
            //  await Task.Run(() => FormData.AssembliesPLFForm(Page, User.Identity.Name, WorkingProfile.SchoolYear, WorkingProfile.SchoolCode));
        }
        protected void ButtonSave_Click(object sender, EventArgs e)
        {


            //List<FormTitle> titlelist = new List<FormTitle>();
            //titlelist = FormData.ListofTitle();
            // List<FormContent> contentlist = new List<FormContent>();
            //  contentlist = FormData.ListofContent(WorkingProfile.SchoolYear, WorkingProfile.SchoolCode);
            //  var newv = "";
        }
        private async Task LoadingPageDataAsync()
        {
            await Task.Run(() => Loading_TitleAsync());
            await Task.Run(() => Loading_DataAsync());
        }

        private void Loading_Title()

        {
            try
            {
                foreach (Control pControl in DataReview.Controls)
                {
                    if (pControl is Label)
                    {
                        string code = pControl.ID.Replace("Label", "");
                        Label lbl = (Label)pControl;
                        lbl.Text = FormData.Title(code);
                    }
                }
                foreach (Control pControl in PLPlanning.Controls)
                {
                    if (pControl is Label)
                    {
                        string code = pControl.ID.Replace("Label", "");
                        Label lbl = (Label)pControl;
                        lbl.Text = FormData.Title(code);
                    }
                }
            }
            catch (Exception ex)
            {
                var ms = ex.Message;
            }
        }
        private void Loading_Data()
        {

            string userID = User.Identity.Name;
            try
            {
                foreach (Control pControl in DataReview.Controls)
                {
                    if (pControl is HtmlTextArea)
                    {
                        string code = pControl.ID.Replace("Text", "");
                        HtmlTextArea txt = (HtmlTextArea)pControl;
                        txt.Value = FormData.Content("Get", userID, WorkingProfile.UserRole, WorkingProfile.SchoolYear, WorkingProfile.SchoolCode, code);
                    }
                }
                foreach (Control pControl in PLPlanning.Controls)
                {
                    if (pControl is HtmlTextArea)
                    {
                        string code = pControl.ID.Replace("Text", "");
                        HtmlTextArea txt = (HtmlTextArea)pControl;
                        txt.Value = FormData.Content("Get", userID, WorkingProfile.UserRole, WorkingProfile.SchoolYear, WorkingProfile.SchoolCode, code);
                    }
                }
            }
            catch (Exception ex)
            {
                var ms = ex.Message;
            }
        }

        private void Loading_TitleAsync()

        {
            try
            {
                foreach (Control pControl in DataReview.Controls)
                {
                    if (pControl is Label)
                    {
                        string code = pControl.ID.Replace("Label", "");
                        Label lbl = (Label)pControl;
                        lbl.Text = FormData.Title(code);
                    }
                }
                foreach (Control pControl in PLPlanning.Controls)
                {
                    if (pControl is Label)
                    {
                        string code = pControl.ID.Replace("Label", "");
                        Label lbl = (Label)pControl;
                        lbl.Text = FormData.Title(code);
                    }
                }
            }
            catch (Exception ex)
            {
                var ms = ex.Message;
            }
        }
        private void Loading_DataAsync()
        {
            try
            {
                string userID = User.Identity.Name;
                foreach (Control pControl in DataReview.Controls)
                {
                    if (pControl is HtmlTextArea)
                    {
                        string code = pControl.ID.Replace("Text", "");
                        HtmlTextArea txt = (HtmlTextArea)pControl;
                        txt.Value = FormData.Content("Get", userID, WorkingProfile.UserRole, WorkingProfile.SchoolYear, WorkingProfile.SchoolCode, code);
                    }
                }
                foreach (Control pControl in PLPlanning.Controls)
                {
                    if (pControl is HtmlTextArea)
                    {
                        string code = pControl.ID.Replace("Text", "");
                        HtmlTextArea txt = (HtmlTextArea)pControl;
                        txt.Value = FormData.Content("Get", userID, WorkingProfile.UserRole, WorkingProfile.SchoolYear, WorkingProfile.SchoolCode, code);
                    }
                }
            }
            catch (Exception ex)
            {
                var ms = ex.Message;
            }
        }



    }
}