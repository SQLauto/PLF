using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PLFSchoolList
    {
        static string sp = "dbo.tcdsb_PLF_SchoolHistory";
        public PLFSchoolList()
        { }

        public static DataSet History(string operate, string userID, string schoolYear, string schoolCode )
        {
            try
            {
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[4];
                SetupThisParameters(ref myPara, operate, userID, schoolYear, schoolCode );
                return SetSQLParameter.getMyDataSet(sp, myPara);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }

        }
        public static DataSet SchoolListByArea(string operate, string userID, string schoolYear, string schoolCode, string schoolArea )
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_SchoolListbyArea";
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[5];
                SetupThisParameters(ref myPara, operate, userID, schoolYear, schoolCode );
                 SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 4, 10, "@SchoolArea", schoolArea);
                return SetSQLParameter.getMyDataSet(sp, myPara);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }

        }
 


        private static void SetupThisParameters(ref myCommon.MyParameterDB[] myPara, string operate, string userID, string schoolYear, string schoolCode )
        {
            myBaseParameters.SetupBaseParameters(ref myPara, operate, userID, schoolYear, schoolCode);
         }
        private static void SetupThisParameters(ref myCommon.MyParameterDB[] myPara, string operate, string userID, string schoolYear, string schoolCode, string searchby, string searchValue)
        {
             myBaseParameters.SetupBaseParameters(ref myPara, operate, userID, schoolYear, schoolCode);
            SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 4, 30, "@Searchby", searchby);
            SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 5, 30, "@SearchValue", searchValue);

        }
    }
 
}
