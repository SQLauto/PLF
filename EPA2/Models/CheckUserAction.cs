using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLF.Models
{
    public class CheckUserAction
    {
        public static string formComplete = "InComplete";
        public static string SchoolSignedOff = "SignedOff";
        public static string SOSignedOff = "Not";
        public static bool ActionPermission(string action, string userRole)
        {
            if (ActionMessage(action, userRole) == "OK")
                return true;
            else
                return false;
        }
        public static string ActionMessage(string action, string userRole)
        {
            var returnMessage = "";
            if (action == "OpenForm")
            {
                if (userRole == "Principal" || userRole == "SiteTeam" || userRole == "Superintendent" || userRole == "Admin")
                    returnMessage = "OK";
                else
                { returnMessage = "No Permission to open the Form!"; }
            }
               
            if (action == "SchoolSignOff")
            {
                if (userRole == "Principal" || userRole == "Admin")
                {
                    if (formComplete == "Complete")
                    { returnMessage = "OK"; }
                    else
                        returnMessage = "Please complete the Form, and then sign Off.";
                }
                else { returnMessage = "No permission to sign off the Form!"; }
            }
            if (action == "SOSignOff")
            {
                if (userRole == "Superintendent" || userRole == "Admin")
                {
                    if (SchoolSignedOff == "SignedOff")
                    { returnMessage = "OK"; }
                    else
                    { returnMessage = "Please have the school Principal sign off first!"; }
                }
                else { returnMessage = "No permission to sign off the Form!"; }
            }
            if (action == "Publish")
            {
                if (userRole == "Principal" || userRole == "Admin")
                {
                    if (SOSignedOff == "SignedOff")
                        returnMessage = "OK";
                    else
                        returnMessage = "Please have your school superintendent sign off first!";
                }
                else { returnMessage = "No permission to Publish the Form!"; }
            }
            return returnMessage;
        }
    }
}