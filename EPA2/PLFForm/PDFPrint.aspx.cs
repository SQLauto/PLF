using BusinessOperation;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLF.PLFForm
{
    public partial class PDFPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                 
                string userID = User.Identity.Name;
                string schoolYear = Page.Request.QueryString["yID"];
                string schoolCode = Page.Request.QueryString["sID"];
                string signType = Page.Request.QueryString["tID"];
                string reportName = Page.Request.QueryString["rID"];
                ReportPrint.RenderPDF(reportName, userID, schoolYear, schoolCode, "1"); 
  
            }

        }
    }
}