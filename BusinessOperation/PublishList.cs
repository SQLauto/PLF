using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessOperation
{
    public static class PublishandSignOffList
    {
        public static void BindGridView(ref GridView myGridView, string listPage, string method, string userID, string schoolYear, string schoolCode)
        {
            try
            {
                if (listPage == "SchoolHistory")
                {
                    string sp = "dbo.tcdsb_PLF_SchoolHistoryNew @SchoolYear,@SchoolCode";
                    School parameter = new School { SchoolYear = schoolYear, SchoolCode = schoolCode };

                    //  List<School> schools = GeneralDataAccess.GetSchoolList(sp, parameter);

                    List<School> schools = GeneralDataAccess.GetListofTypeT<School>(sp, parameter);
                    myGridView.DataSource = schools;
                    myGridView.DataBind();
                }
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }

        public static void BindGridView(ref GridView myGridView, string listPage, string method, string userID, string schoolYear, string schoolCode, string schoolArea)
        {
            try
            {
                if (listPage == "SchoolListbyArea")
                {
                    string sp = "dbo.tcdsb_PLF_AreaSchoolListNew @SchoolYear,@SchoolCode,@SchoolArea";
                    School parameter = new School { SchoolYear = schoolYear, SchoolCode = schoolCode, SchoolArea = schoolArea };

                    //   List<School> schools = GeneralDataAccess.GetSchoolList(sp, parameter);
                    List<School> schools = GeneralDataAccess.GetListofTypeT<School>(sp, parameter);

                    // List<School> schools = PublishList.GetAreaSchools("Get", "Role", userID, schoolyear, schoolcode, schoolArea); ;
                    myGridView.DataSource = schools;
                    myGridView.DataBind();
                }
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }
        public static void BindGridView(ref GridView myGridView, string GridType, School parameter)
        {
            try
            {
                string sp = "";
                if (GridType == "SchoolHistory")
                { sp = "dbo.tcdsb_PLF_SchoolHistoryNew @SchoolYear,@SchoolCode"; }
                if (GridType == "SchoolListbyArea")
                { sp = "dbo.tcdsb_PLF_AreaSchoolListNew @SchoolYear,@SchoolCode,@SchoolArea"; }

                //  School parameter = new School { SchoolYear = schoolYear, SchoolCode = schoolCode, SchoolArea = schoolArea };
                List<School> schools = GeneralDataAccess.GetListofTypeT<School>(sp, parameter);
                myGridView.DataSource = schools;
                myGridView.DataBind();

            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }

    }
}
