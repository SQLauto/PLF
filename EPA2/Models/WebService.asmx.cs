using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessOperation;
namespace PLF.Models
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]


    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string GetHelpContent(string operation, string userID, string CategoryID, string AreaID, string ItemCode)
        {
            try
            {
                return HelpText.GetHelpContent(operation, userID, CategoryID, AreaID, ItemCode,"Help");
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }
        [WebMethod]
        public string SaveHelpContent(string operation, string userID, string CategoryID, string AreaID, string ItemCode, string value)
        {
            try
            {
                return HelpText.GetHelpContent(operation, userID, CategoryID, AreaID, ItemCode,  value);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }
        [WebMethod]
        public string GetTitleContent(string operation, string userID, string CategoryID, string AreaID, string ItemCode)
        {
            try
            {
                return HelpText.GetHelpContent(operation, userID, CategoryID, AreaID, ItemCode);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }
        [WebMethod]
        public string SaveTitleContent(string operation, string userID, string CategoryID, string AreaID, string ItemCode, string title, string subtitle)
        {
            try
            {
                return HelpText.GetHelpContent(operation, userID, CategoryID, AreaID, ItemCode, title );
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }

        [WebMethod]
        public string SaveText( string userID, string schoolyear, string schoolcode, string itemcode, string value )
        {
            try
            {
                return  FormData.TextContent("Save", userID, "",schoolyear, schoolcode, itemcode, value);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "failed";
            }
        }
        [WebMethod]
        public string SaveTeam(string userID, string schoolyear, string schoolcode, string teacherID, string checkValue,string comments,string action)
        {
            try
            {
                return SiteTeamSetup.TeamMemberSelect("Save",userID,  schoolyear, schoolcode, action,teacherID,checkValue,comments);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "failed";
            }
        }
   
    }
}
