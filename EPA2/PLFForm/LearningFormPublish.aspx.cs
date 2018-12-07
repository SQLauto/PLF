using BusinessOperation;
using DataAccess;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLF.PLFForm
{
    public partial class LearningFormPublish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                   // LabelTitle.Text = "PLF Publish Verify";
                  //  btnReturn.Visible = false;
                    string actionName = "Publish";
                    string userID = User.Identity.Name;
                    string schoolyear = Page.Request.QueryString["yID"];
                    string schoolcode = Page.Request.QueryString["sID"];
                    string signType = Page.Request.QueryString["tID"];
                    string signOffResult = SignOff.Signature2("Result", userID,   schoolyear, schoolcode, "SO");
                    txtUserName.Text = User.Identity.Name;
                    txtUserName.Enabled = false;
                    if (signOffResult != "SignedOff")
                    {
                       // btnReturn.Enabled = false;
                        errorlabel.Visible = true;
                        errorlabel.ForeColor = Color.Red;
                        errorlabel.Text = "Superintendent has to signed off first before you can publish the your school PLF.";
                    }
                    btnReturn.Text = actionName;
                    //  string signOffName = "School Principal";

                    // LabelTitle.Text = signOffName + " " + actionName;

                    //   btnReturn.Attributes.Add("OnClick", "javascript:ReturnVerify()");
                    SignOffDateDiv.Visible = false;
                }



                catch (Exception exp)
                {
                    var sm = exp.Message;
                }
            }
        }
        protected void btnVerifyUser_Click(object sender, EventArgs e)
        {
            try
            {
                txtUserName.Text = txtUserName.Text.ToLower();
                if (Authentication.IsAuthenticated(txtDomain.Text, txtUserName.Text, txtPassword.Text))
                {
                    PassVerify();
                }
                else
                {
                    ChekVerify("Verify Failed. Check user name and password. ");
                    errorlabel.Text = "Error Login User ID or Passward !";
                    errorlabel.Visible = true;
                    txtPassword.Focus();
                }
            }
            catch (Exception exp)
            {
                string exM = exp.Message;
                CheckFailed("Authenticating Failed");
            }
        }
        private void ChekVerify(string vMsg)
        {
            if (WebConfig.getValuebyKey("AuthenticateMethod") == "NameOnly")
            {
                PassVerify();
            }
            else
            {
                CheckFailed(vMsg);
            }
        }
        private void CheckFailed(string vMsg)
        {
            errorlabel.ForeColor = Color.Red;
            errorlabel.Text = vMsg;
            // hfVerify.Value = True;
        }
        private void PassVerify()
        {
          

            string singName = User.Identity.Name;
            SignOffDateDiv.Visible = true;
         //   errorlabel.Visible = false;
            btnVerifyUser.Visible = false;
            errorlabel.Text = "Verification confirmed, entry Date to Publish";
            errorlabel.ForeColor = Color.Red;

        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {

            string userID = User.Identity.Name;
           string schoolyear  = Page.Request.QueryString["yID"];
            string schoolcode = Page.Request.QueryString["sID"];
            string signType = Page.Request.QueryString["tID"];

            string action = btnReturn.Text;
            string vDate = DateFC.YMD(DateTime.Now);
            string signOffResult = SignOff.Signature2(action, userID,  schoolyear, schoolcode, "Publish", vDate);
            CreateReportandSaveToDB(schoolyear, schoolcode, "1", "All", WorkingProfile.SchoolName, WorkingProfile.SchoolNameB);

        }
        private void CreateReportandSaveToDB(string schoolYear, string schoolCode ,string publishCycle, string GoalType, string schoolName , string schoolNameB )
        {
             
            string reportName =  WebConfig.getValuebyKey("PublishDocumentName");
      
            string userID = WorkingProfile.UserID;
        

            string publishDate = DateFC.YMD( DateTime.Now);

           Byte[] pdfReport = ReportRender.GetOneReport(reportName, userID,schoolYear, schoolCode,"1" );

            string result = PushToSP.PublishPLFtoSharePointSite("SLIP", pdfReport, schoolYear, schoolCode, schoolName, schoolNameB); 
            //  UploadFileToSharePointSite.PushToSite("SLIP", pdfReport, schoolYear, schoolCode, schoolName, schoolNameB);
            if (result == "Successful")
            {
                string action = btnReturn.Text;
                string signOffResult = SignOff.Signature2(action, userID,  schoolYear, schoolCode, "Publish", publishDate);
               // SaveSLIPPublishDataToHistoryDirectory(schoolCode + ".PDF", pdfReport);
                errorlabel.Text = "The School PLF has been published to School Web site.";
                errorlabel.ForeColor =  Color.Red;
               //   PushToSP.SaveFileToHistoryFolder(WorkingProfile.SchoolYear, schoolCode + ".PDF", pdfReport);
          }
            else {
                errorlabel.Text = "The School PLF published failed to School Web site.";
            }
            

       }
 
    }
}