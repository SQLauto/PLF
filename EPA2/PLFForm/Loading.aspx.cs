using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
namespace PLF.PLFForm
{
    public partial class Loading : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string GoPage = Page.Request.QueryString["pID"];
                string schoolyear = Page.Request.QueryString["yID"];
                string schoolcode = Page.Request.QueryString["sID"];
                string sType = Page.Request.QueryString["sType"];
                string parameter = "yID=" + schoolyear + "&sID=" + schoolcode + "&tID=" + sType;
                switch (GoPage)
                {

                    case "FormPublish":
                        GoPage = "LearningFormPublish.aspx?" + parameter;
                        break;
                    case "FormSignOff":
                        GoPage = "LearningFormSignOff.aspx?" + parameter;
                        break;
                    case "FormContent":
                        GoPage = "LearningForm.aspx?" + parameter  ;
                        break;
                    default:
                        GoPage = "LearningForm.aspx?" + parameter;
                        break;
                }

                PageURL.HRef = GoPage;
            }
        }
    }
}