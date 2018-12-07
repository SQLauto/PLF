using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessOperation;
using DataAccess;
using System.Drawing;

namespace PLF.PLFForm
{
    public partial class LearningFormSignOff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // btnReturn.Visible = false;
                string userID = User.Identity.Name;
                string schoolyear = Page.Request.QueryString["yID"];
                string schoolcode = Page.Request.QueryString["sID"];
                string signType = Page.Request.QueryString["tID"];
                string signOffResult = SignOff.Signature2("Result", userID,  schoolyear, schoolcode, signType);
                string actionName = "Sign Off";
                if (signOffResult == "SignedOff")
                {
                    actionName = "Undo SignOff";
                }
                btnReturn.Text = actionName;
                string signOffName = "School Principal";
                if (signType != "School")
                {
                    signOffName = "Superintendent";
                }
                if (WorkingProfile.UserRole == "Superintendent")
                {
                    signOffName = "Superintendent";
                    signType = "SO";
                }
                LabelSignOffTitle.Text = signOffName + " " + actionName;
                txtUserName.Text = User.Identity.Name;
                txtUserName.Enabled = false;
                // btnReturn.Attributes.Add("OnClick", "javascript:ReturnVerify()");
                SignOffDateDiv.Visible = false;
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
                    CheckVerify("Verify Failed. Check user name and password. ");
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
        private void CheckVerify(string vMsg)
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
            errorlabel.Visible = false;
            btnVerifyUser.Visible = false;
   
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                string userID = User.Identity.Name;
                string schoolyear = Page.Request.QueryString["yID"];
                string schoolcode = Page.Request.QueryString["sID"];
                string signType = Page.Request.QueryString["tID"];
                if (WorkingProfile.UserRole == "Superintendent")
                { signType = "SO"; }
                string action = btnReturn.Text;
                DateTime cDate = DateTime.Now;
                string vDate = DateFC.YMD(cDate);
                string signOffResult = SignOff.Signature2("SignOff", userID,  schoolyear, schoolcode, signType, vDate);
            }
            catch (Exception exp)
            {
                var em = exp.Message;
            }


        }

    }
}