using System.Web;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using DataAccess;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using PLF.Generic.LIB;
/// <summary>
/// Summary description for WorkingProfile
/// </summary>
/// 


namespace PLF
{
    public class ListGridViewData : System.Web.UI.Page
    {
        public ListGridViewData()
        {

        }
        public static void BindMyGridView(ref GridView myGridView, string listPage, string method, string userID, string schoolyear, string schoolcode)
        {
            try
            {
                if (listPage == "SchoolHistory")
                {
                    SchoolHistoryGridView(ref myGridView, method, userID, schoolyear, schoolcode );
                }
                

            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }
        public static void BindMyGridView(ref GridView myGridView,string listPage, string method, string userID, string schoolyear, string schoolcode, string schoolArea )
        {
            try
            {
                if (listPage == "SchoolListbyArea")
                {
                    SchoolListByAreaGridView(ref myGridView, method, userID, schoolyear, schoolcode, schoolArea);
                }
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }
       
    
        private static void SchoolHistoryGridView(ref GridView myGridView, string method, string userID, string schoolyear, string schoolcode )
        {
            try
            {
                if (method == "DataSet")
                {
                     DataTable gridData = PLFSchoolList.History("Get", userID, schoolyear, schoolcode).Tables[0];
                    myGridView.DataSource = gridData;
                    myGridView.DataBind();
                }
                if (method == "iList")
                {
                    IListRepository<Employee2, string> repository = Factory.Get<EmployeeList>(); 
                    IList<Employee2> gridData = repository.GetListItems(WorkingProfile.UserRole, userID, schoolyear, schoolcode );
                    myGridView.DataSource = gridData;
                    myGridView.DataBind();
                }

            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }
        private static void SchoolListByAreaGridView(ref GridView myGridView, string method, string userID, string schoolyear, string schoolcode,string schoolArea)
        {
            try
            {
                if (method == "DataSet")
                {
                    DataTable gridData = PLFSchoolList.SchoolListByArea("Get", userID, schoolyear, schoolcode, schoolArea).Tables[0];
                    myGridView.DataSource = gridData;
                    myGridView.DataBind();
                }
                if (method == "iList")
                {
                    IListRepository<Employee2, string> repository = Factory.Get<EmployeeList>();
                    IList<Employee2> gridData = repository.GetListItems(WorkingProfile.UserRole, userID, schoolyear, schoolcode); //, schoolArea);
                    myGridView.DataSource = gridData;
                    myGridView.DataBind();
                }
                if (method == "Dapper")
                {
                    List<School> schools = new List<School>();
                    DataAccessLay dataaccesslay = new DataAccessLay();
                    schools = dataaccesslay.GetSchools("Get", userID, schoolyear, schoolcode, schoolArea);
                    myGridView.DataSource = schools;
                    myGridView.DataBind();
                }
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }
   
    }
}