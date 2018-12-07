using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLF
{
    public partial class Loading : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string GoPage = Page.Request.QueryString["pID"].ToString();

                if (GoPage == "")
                {
                    GoPage = "~/SchoolManage/SchoolList.aspx";
                }
                switch (GoPage)
                {
                    case "PLFDefination":
                        GoPage = "PLFSystem/systemDefination.aspx";
                        break;
                    case "PLFUsers":
                        GoPage = "PLFSystem/systemDefination.aspx";
                        break;
                    case "WorkProcess":
                        GoPage = "PLFSystem/systemDefination.aspx";
                        break;
                    case "PLFCurrentYearForm":
                        GoPage = "PLFForm/SchoolList.aspx";
                        break;
                    case "PLFHistoryForm":
                        GoPage = "PLFForm/History.aspx";
                        break;
                    case "SchoolTeam":
                        GoPage = "PLFForm/SchoolTeam.aspx";
                        break;
                    case "UserGuideline":
                        GoPage = "Documents/Loading.aspx"; ;
                        break;
                    case "PLFForm":
                    case "HomePage":
                        switch (WorkingProfile.UserRole)
                        {
                            case "Superintendent":
                                GoPage = "PLFForm/SchoolList.aspx";
                                break;
                            case "Admin":
                                GoPage = "PLFForm/SchoolList.aspx";
                                break;
                            case "Principal":
                                GoPage = "PLFForm/History.aspx";
                                break;
                            case "Team":
                                GoPage = "PLFForm/History.aspx";
                                break;
                            default:
                                GoPage = "PLFForm/History.aspx";
                                break;
                        }
                        break;
                    default:
                      
                        GoPage = "PLFSystem/Feedback.aspx";
                        break;
                }

                PageURL.HRef = GoPage;
            }
        }
    }
}