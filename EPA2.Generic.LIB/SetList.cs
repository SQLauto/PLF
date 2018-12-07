using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF.Generic.LIB
{

    public class SetList
    {
        public static void SetLists(System.Web.UI.WebControls.DropDownList myListControl, string operate, string userID )
        {
            List<MyListItem> myList = new List<MyListItem>();
            DataAccessLay dataaccesslay = new DataAccessLay();
            myList = dataaccesslay.GetLists(operate, userID);
            AssemblingSchoolList(myListControl, myList);
        }
        private static void AssemblingSchoolList(System.Web.UI.WebControls.DropDownList myListControl , List<MyListItem> myData)
        {
            try
            {
                List<MyListItem> myList = myData;
                myListControl.Items.Clear();
                myListControl.DataSource = myList;
                myListControl.DataTextField = "myValue";
                myListControl.DataValueField = "myValue";
                myListControl.DataBind();

            
            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }

   
        public static void SetLists2(System.Web.UI.WebControls.DropDownList myListControl, System.Web.UI.WebControls.DropDownList myListControl2, string operate, string userID, string vPara1, string vPara2, string vPara3)
        {
            List<MyListItem> myList = new List<MyListItem>();
            DataAccessLay dataaccesslay = new DataAccessLay();
            myList = dataaccesslay.GetLists("SchoolListP", userID, vPara1, vPara2, vPara3);
            AssemblingSchoolList(myListControl, myListControl2, myList);
        }
        private static void AssemblingSchoolList(System.Web.UI.WebControls.DropDownList myListControl, System.Web.UI.WebControls.DropDownList myListControl2, List<MyListItem> myData)
        {
            try
            {
                List<MyListItem> myList = myData;
                myListControl.Items.Clear();
                myListControl.DataSource = myList;
                myListControl.DataTextField = "myValue";
                myListControl.DataValueField = "myValue";
                myListControl.DataBind();

                myListControl2.Items.Clear();
                myListControl2.DataSource = myList;
                myListControl2.DataTextField = "myText";
                myListControl2.DataValueField = "myValue";
                myListControl2.DataBind();
            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }
        
 
    }

}

