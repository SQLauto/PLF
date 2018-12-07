using System.Web;
using System.Data;
using System.Web.Security;
using System.Web.UI;
/// <summary>
/// Summary description for WorkingProfile
/// </summary>
/// 
using DataAccess;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using System.Collections.Generic;

namespace PLF
{
    public class ApplicationSetup : System.Web.UI.Page
    {
        public ApplicationSetup()
        {

        }
        public static void OBJList(ref GridView myDataView, string action, string userID, string category, string area)
        {

            if (action == "Get")
            {
                DataTable gridData = ApplicationSetupData.UserRoleManagement(action, userID, category, area).Tables[0];
                myDataView.DataSource = gridData;
                myDataView.DataBind();
            }
        }
        public static string OBJList(ref GridView myDataView, string action, string userID, string category, string area, string IDs, string roleCode, string roleName, string comments, string active)
        {

            string result = ApplicationSetupData.UserRoleManagement(action, userID, category, area, IDs, roleCode, roleName, comments, active);
            return result;
        }
        public static void UsersList(ref GridView myDataView, string action, string userID, string category, string area)
        {

            if (action == "Get")
            {
                DataTable gridData = ApplicationSetupData.UsersManagement(action, userID, category, area).Tables[0];
                myDataView.DataSource = gridData;
                myDataView.DataBind();
            }
        }
        public static string UsersList(string action, string userID, string category, string area, string IDs, string usersID, string usersName, string userRole, string comments, string active)
        {

            string result = ApplicationSetupData.UsersManagement(action, userID, category, area, IDs, usersID, usersName, userRole, comments, active);
            return result;
        }

        public static void MultipleSchoolUser(ref GridView myDataView, string action, string userID, string category, string area, string schoolyear)
        {

            DataTable gridData = ApplicationSetupData.UsersManagementMultipleSchool(action, userID, category, area, schoolyear).Tables[0];
            myDataView.DataSource = gridData;
            myDataView.DataBind();

        }

        public static void DistrictList(ref GridView myDataView, string action, string userID, string category, string area)
        {

            if (action == "Get")
            {
                DataTable gridData = ApplicationSetupData.SchoolDistrict(action, userID, category, area).Tables[0];
                myDataView.DataSource = gridData;
                myDataView.DataBind();
            }
        }
        public static string DistrictList(ref GridView myDataView, string action, string userID, string category, string area, string IDs, string roleCode, string roleName, string comments, string active)
        {

            string result = ApplicationSetupData.SchoolDistrict(action, userID, category, area, IDs, roleCode, roleName, comments, active);
            return result;
        }

        public static void RegionList(ref GridView myDataView, string action, string userID, string category, string area)
        {

            if (action == "Get")
            {
                DataTable gridData = ApplicationSetupData.RegionAreaList(action, userID, category, area).Tables[0];
                myDataView.DataSource = gridData;
                myDataView.DataBind();
            }
        }
        public static string RegionList(string action, string userID, string category, string area, string IDs, string roleCode, string roleName, string comments, string active, string district, string superID, string officer)
        {

            string result = ApplicationSetupData.RegionAreaList(action, userID, category, area, IDs, roleCode, roleName, comments, active, district, superID, officer);
            return result;
        }
        public static void SchoolList(ref GridView myDataView, string action, string userID, string category, string area)
        {

            if (action == "Get")
            {
                DataTable gridData = ApplicationSetupData.SchoolList(action, userID, category, area).Tables[0];
                myDataView.DataSource = gridData;
                myDataView.DataBind();
            }
        }
        public static string SchoolList(string action, string userID, string category, string area, string IDs, string schoolCode, string schoolName, string comments, string active, string district, string header, string supervisor)
        {

            string result = ApplicationSetupData.SchoolInformation(action, userID, category, area, IDs, schoolCode, schoolName, comments, active, district, header, supervisor, "1", "1", "1");
            return result;
        }
        public static void SystemItems(ref GridView myDataView, string action, string userID, string category, string ItemType)
        {

            if (action == "Get")
            {
                DataTable gridData = ApplicationSetupData.SystemItems(action, userID, category, ItemType).Tables[0];
                myDataView.DataSource = gridData;
                myDataView.DataBind();
            }
        }
        public static void CategoryList(ref GridView myDataView, string action, string userID)
        {

            if (action == "Get")
            {
                DataTable gridData = ApplicationSetupData.Category(action, userID).Tables[0];
                myDataView.DataSource = gridData;
                myDataView.DataBind();
            }
        }

        public static void DomainList(ref GridView myDataView, string action, string userID, string category, string area)
        {

            if (action == "Get")
            {
               // IRepository<Domain2,int> repository = new GenericDomain2();
                
               //IList<Domain2> mylsit = repository.GetListItems(action,userID,category,area);


                DataTable gridData = ApplicationSetupData.Domain(action, userID, category, area).Tables[0];
                myDataView.DataSource = gridData;// mylsit;//
                myDataView.DataBind();
            }
        }

        public static void CompetencyList(ref GridView myDataView, string action, string userID, string category, string area)
        {
            //IRepository<Competency2, int> repository = new GenericCompetency2();
            //IList<Competency2> mylsit = repository.GetListItems(action, userID, category, area);

            DataTable gridData = ApplicationSetupData.Competency(action, userID, category, area).Tables[0];
            myDataView.DataSource = gridData; // mylsit; //
            myDataView.DataBind();

        }
        public static void CompetencyList(ref GridView myDataView, string action, string userID, string category, string area,string lookfor)
        {
            //IRepository<Competency3, int> repository = new GenericCompetency3();
            //IList<Competency3> mylsit = repository.GetListItems(action, userID, category, area);

            DataTable gridData = ApplicationSetupData.Competency(action, userID, category, area).Tables[0];
            myDataView.DataSource =gridData; // mylsit; //
            myDataView.DataBind();

        }
        public static void LookForsList(ref GridView myDataView, string action, string userID, string category, string area, string competencyID)
        {
            //IRepository<Lookfors2, int> repository = new GenericLookfors2();
            //IList<Lookfors2> mylsit = repository.GetListItems(action, userID, category, area, competencyID);

           DataTable gridData = ApplicationSetupData.LookFors(action, userID, category, area, competencyID).Tables[0];
            myDataView.DataSource = gridData;//mylsit;//  
            myDataView.DataBind();

        }
        public static void CommentBankList(ref GridView myDataView, string action, string userID, string category, string area, string type, string owner)
        {
            DataTable gridData = ApplicationSetupData.CommentsBank(action, userID, category, area, type, owner).Tables[0];
            myDataView.DataSource = gridData;
            myDataView.DataBind();
        }
        
        public static void Statements(ref TextBox myText, ref TextBox myTopic, ref HtmlInputText startDate, ref HtmlInputText endDate, string schoolyear, string schoolcode, string statementType, string area, string action, string userID, string IDs)
        {
            if (action == "New")
            {
                string result = ApplicationSetupData.Statements(action, userID, schoolyear, schoolcode, statementType, area);
            }
            else if (action == "Get" )
            {
                DataTable DT = ApplicationSetupData.Statements(action, userID, schoolyear, schoolcode, statementType, area, IDs).Tables[0];
                if (DT.Rows.Count > 0)
                {
                    myText.Text = DT.Rows[0][1].ToString();
                    myTopic.Text = DT.Rows[0][2].ToString();
                    startDate.Value = DT.Rows[0][3].ToString();
                    endDate.Value = DT.Rows[0][4].ToString();
                }
            }
            else
            {
                string statement = myText.Text;
                string topic = myTopic.Text;
                string dateStart = startDate.Value;
                string dateEnd = endDate.Value;

                string result = ApplicationSetupData.Statements(action, userID, schoolyear, schoolcode, statementType, area, IDs, statement, topic, dateStart, dateEnd);
            }
        }

    }

}