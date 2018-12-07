using System.Web;
using System.Web.Security;
using System.Web.UI;
/// <summary>
/// Summary description for WorkingProfile
/// </summary>
/// 
using DataAccess;
namespace PLF
{
    public class WorkingProfile : System.Web.UI.Page
    {
        public WorkingProfile()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
        public static string UserID
        { get
           
            {
                return HttpContext.Current.User.Identity.Name;
            }
  
        }
        public static string UserEmployeeID
        {
            get

            {
                return UserProfile.LoginUserEmployeeID;
            }

        }
        public static string UserName
        {
            get

            {
                return UserProfile.LoginUserName;
            }

        }

        public static string UserRole
        {
            get
            {
                if (HttpContext.Current.Session["userrole"] == null)
                {
                    HttpContext.Current.Session["userrole"] = UserProfile.Role;
                }
                return HttpContext.Current.Session["userrole"].ToString();
            }
            set
            {
                HttpContext.Current.Session["userrole"] = value;
            }
        }
        public static string UserRoleLogin
        {
            get
            {
                if (HttpContext.Current.Session["userrolelogin"] == null)
                {
                    HttpContext.Current.Session["userrolelogin"] = UserProfile.Role;
                }
                return HttpContext.Current.Session["userrolelogin"].ToString();
            }
            set
            {
                HttpContext.Current.Session["userrolelogin"] = value;
            }
        }
       public static string UserAppraisalRole
        {
            get
            {
                if (HttpContext.Current.Session["userappraisalrole"] == null)
                {
                    HttpContext.Current.Session["userappraisalrole"] = UserProfile.Role;
                }
                return HttpContext.Current.Session["userappraisalrole"].ToString();
            }
            set
            {
                HttpContext.Current.Session["userappraisalrole"] = value;
            }
        }
        public static string ClientUserScreen
        {
            get
            {
                if (HttpContext.Current.Session["clientuserscreen"] == null)
                {
                    HttpContext.Current.Session["clientuserscreen"] = UserLastWorking.ClientScreen;
                }

                return HttpContext.Current.Session["clientuserscreen"].ToString();
            }
            set
            {
                HttpContext.Current.Session["clientuserscreen"] = value;

            }
        }
         public static string ImageFileID 
        {
            get 
            {
                 return HttpContext.Current.Session["imagefileID"].ToString();
            }
            set
            {
                HttpContext.Current.Session["imagefileID"] = value;
             }
        }
         public static string Model 
        {
            get 
            {
                 return WebConfig.getValuebyKey("ApplicationModel");
            }
  
        }
        public static string PageCategory
        {
            get
            {

                return HttpContext.Current.Session["pagecategoryID"].ToString();
            }
            set
            {
                HttpContext.Current.Session["pagecategoryID"] = value;
            }
        }
        public static string PageArea
        {
            get
            {

                return HttpContext.Current.Session["pageareaID"].ToString();
            }
            set
            {
                HttpContext.Current.Session["pageareaID"] = value;
            }
        }
        public static string PageItem
        {
            get
            {
                return HttpContext.Current.Session["pageItemID"].ToString();
            }
            set
            {
                HttpContext.Current.Session["pageItemID"] = value;
            }
        }
        public static string cSchoolYear
        {
            get
            {
                if (HttpContext.Current.Session["cschoolyear"] == null)
                {
                    HttpContext.Current.Session["cschoolyear"] = UserLastWorking.CurrentSchoolYear;
                }
                return HttpContext.Current.Session["cschoolyear"].ToString();
            }
            set
            {
                HttpContext.Current.Session["cschoolyear"] = value;
            }
        }
        public static string SchoolYear
        {
            get
            {
                if (HttpContext.Current.Session["schoolyear"] == null)
                {
                    HttpContext.Current.Session["schoolyear"] = UserLastWorking.SchoolYear;
                }
                return HttpContext.Current.Session["schoolyear"].ToString();
            }
            set
            {
                HttpContext.Current.Session["schoolyear"] = value;
                UserLastWorking.SchoolYear = value;
            }
        }
        public static string SchoolCode
        {
            get
            {
                if (HttpContext.Current.Session["schoolcode"] == null)
                {
                    HttpContext.Current.Session["schoolcode"] = UserLastWorking.SchoolCode;
                }
                return HttpContext.Current.Session["schoolcode"].ToString();
            }
            set
            {
                HttpContext.Current.Session["schoolcode"] = value;
                UserLastWorking.SchoolCode = value;
             }
        }
        public static string SchoolName
        {
            get
            {
                if (HttpContext.Current.Session["schoolname"] == null)
                {
                    HttpContext.Current.Session["schoolname"] = UserLastWorking.SchoolName;
                }
                return HttpContext.Current.Session["schoolname"].ToString();
            }
            set
            {
                HttpContext.Current.Session["schoolname"] = value;
            }
        }
        public static string SchoolNameB
        {
            get
            {
                if (HttpContext.Current.Session["schoolnameb"] == null)
                {
                    HttpContext.Current.Session["schoolnameb"] = UserLastWorking.SchoolNameB;
                }
                return HttpContext.Current.Session["schoolnameb"].ToString();
            }
            set
            {
                HttpContext.Current.Session["schoolnameb"] = value;
            }
        }
        public static string SchoolPrincipal
        {
            get
            {
                if (HttpContext.Current.Session["schoolprincipal"] == null)
                {
                    HttpContext.Current.Session["schoolprincipal"] = UserLastWorking.SchoolPrincipal;
                }
                return HttpContext.Current.Session["schoolprincipal"].ToString();
            }
            set
            {
                HttpContext.Current.Session["schoolprincipal"] = value;
            }
        }
        public static string OpenSchoolYear
        {
            get
            {
                if (HttpContext.Current.Session["openschoolyear"] == null)
                {
                    HttpContext.Current.Session["openschoolyear"] = UserLastWorking.OpenSchoolYear;
                }
                return HttpContext.Current.Session["openschoolyear"].ToString();
            }
            set
            {
                HttpContext.Current.Session["openschoolyear"] = value;
            }
        }

        public static string UserArea
        {
            get
            {
                if (HttpContext.Current.Session["userarea"] == null)
                {
                    HttpContext.Current.Session["userarea"] = UserLastWorking.UserArea;
                }
                return HttpContext.Current.Session["userarea"].ToString();
            }
            set
            {
                HttpContext.Current.Session["userarea"] = value;
            }
        }
        public static string UserAreaSuperintendent
        {
            get
            {
                if (HttpContext.Current.Session["userareasuperintendent"] == null)
                {
                    HttpContext.Current.Session["userareasuperintendent"] = UserLastWorking.UserAreaSuperintendent;
                }
                return HttpContext.Current.Session["userareasuperintendent"].ToString();
            }
            set
            {
                HttpContext.Current.Session["userareasuperintendent"] = value;
            }
        }

    }
}