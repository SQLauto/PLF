using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using Dapper;
using System.Data.SqlClient;

namespace DataAccess
{
    public class PLFFormData
    {
         static string sp = "dbo.tcdsb_PLF_Form";
        public PLFFormData()
        { }
        public static string Title(string userID, string itemCode)
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_GetItemLabel";
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[2];
                 SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 0, 30, "@UserID", userID);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 1, 10, "@ItemCode", itemCode);
                return SetSQLParameter.getMyDataValue(sp, myPara);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }
        } 
        public static string TextValue(string operate, string userID, string schoolYear, string schoolCode, string itemCode)
        {
            try
            {
                
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[5];
                SetupThisParameters(ref myPara,operate, userID, schoolYear, schoolCode);
                 SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 4, 10, "@ItemCode", itemCode);
               return SetSQLParameter.getMyDataValue(sp, myPara);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }
        }
        public static string TextValue(string operate, string userID, string schoolYear, string schoolCode, string itemCode,string value)
        {
            try
            {
              
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[6];
                SetupThisParameters(ref myPara, operate, userID, schoolYear, schoolCode);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 4, 10, "@ItemCode", itemCode);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 5, 5000, "@Notes", value);
                return SetSQLParameter.getMyDataValue(sp, myPara);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }
        }
        public static string SignOff(string operate, string userID, string schoolYear, string schoolCode, string actionType)
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_Form_SignOff";
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[5];
                SetupThisParameters(ref myPara, operate, userID, schoolYear, schoolCode);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 4, 20, "@ActionType", actionType);
                 return SetSQLParameter.getMyDataValue(sp, myPara);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }
        }
        public static string SignOff(string operate, string userID, string schoolYear, string schoolCode, string actionType, string actionDate)
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_Form_SignOff";
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[6];
                SetupThisParameters(ref myPara, operate, userID, schoolYear, schoolCode);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 4, 20, "@ActionType", actionType);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 5, 10, "@ActionDate", actionDate);
                return SetSQLParameter.getMyDataValue(sp, myPara);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }
        }

        public static string TeamSetup(string operate, string userID, string schoolYear, string schoolCode )
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_SchoolSiteTeam";
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[4];
                SetupThisParameters(ref myPara, operate, userID, schoolYear, schoolCode);
                 return SetSQLParameter.getMyDataValue(sp, myPara);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }
        }
        public static string TeamSetup(string operate, string userID, string schoolYear, string schoolCode, string teacherID, string checkvalue, string coments, string action)
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_SchoolSiteTeam";
                myCommon.MyParameterDB[] myPara = new myCommon.MyParameterDB[6];
                SetupThisParameters(ref myPara, operate, userID, schoolYear, schoolCode);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 4, 20, "@TeacherID", teacherID);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 5, 10, "@Checked", checkvalue);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 6, 250, "@Comments", coments);
                SetSQLParameter.setParameterArray(myPara, System.Data.DbType.String, 7, 20, "@Action", action);
                return SetSQLParameter.getMyDataValue(sp, myPara);
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


