using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Configuration;
namespace BusinessOperation
{
   public  class WebConfigB
    {
        public static string getValuebyKey(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }
        public static string RunningModel()
        {
            return getValuebyKey("RunningModel");
        }
        public static string SchoolSystem()
        {
            return getValuebyKey("SchoolSystem");
        }
        public static string currentDatabase()
        {
            return getValuebyKey("currentDB");
        }
        public static string LDAPServer()
        {
            return getValuebyKey("LDAP");
        }
        public static string Reportsource()
        {
            return getValuebyKey("Reportsource");
        }
        public static string ReportServer()
        {
            return getValuebyKey("ReportServer");
        }
        public static string ReportServices()
        {
            return getValuebyKey("ReportingService");
        }
        public static string ReportPath()
        {
            return getValuebyKey("ReportPath");
        }
        public static string ReportFormat()
        {
            return getValuebyKey("ReportFormat");
        }
        public static string ReportPath2(string vSES)
        {
            return getValuebyKey("ReportPath") + vSES;
        }
        public static string ReportPathWS()
        {
            return getValuebyKey("ReportPathWS");
        }
        public static string ReportUser()
        {
            return getValuebyKey("WebServiceUser");
        }
        public static string ReportPW()
        {
            return getValuebyKey("WebServiceWP");
        }
        public static string DomainName()
        {
            return getValuebyKey("NetWorkDomain");
        }
        public static string AppName()
        {
            return getValuebyKey("Application");
        }
      
        public static string eMailGo()
        {
            return getValuebyKey("eMailTry");
        }

        public static string MessageNotAllow()
        {
            return getValuebyKey("MessageNoPermission");
        }
        public static string MessageLogin()
        {
            return getValuebyKey("MessageLogin");
        }
        public static string MessageDB()
        {
            return getValuebyKey("MessageDB");
        }
    }
    public class DBConnectionB
    { 
        public static string CurrentDB
        {
            get { return getNamebyKey("CurrentDB"); }
        }
        public static string TestDB
        {
            get { return getNamebyKey("Test"); }
        }
        public static string LiveDB
        {
            get { return getNamebyKey("Live"); }
        }
        public static string ConnectionSTR(string name)
        {
            return getNamebyKey(name);
        }
        public static string AuthMethod()
        {
            return getNamebyKey("LDAP");
        }
        private static string getNamebyKey(string name)
        {
           // return WebConfigurationManager.ConnectionStrings[name].ToString(); // .ConnectionStrings(_name).ToString;
            string currentDB = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return currentDB; //  ConfigurationManager.ConnectionStrings[currentDB].ConnectionString;
            //   return System.Configuration.ConfigurationManager.ConnectionStrings[name].ToString();

        }
        
    }
}
