using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Common;

namespace BusinessOperation
{
   public class SignOff
    {
        static string sp = "dbo.tcdsb_PLF_Form_SignOffNew @Operate,@UserID,@SchoolYear,@SchoolCode,@ActionType";

        public static string SignatureOld(string operate, string userID, string userRole, string schoolYear, string schoolCode, string actionType)
        {
            ParameterSP1 parameter = new ParameterSP1 { Operate = operate, UserID = userID,  UserRole=userRole,  SchoolYear = schoolYear, SchoolCode = schoolCode, ActionType =actionType };
            return GeneralDataAccess.TextValue(sp ,  parameter);
     
           // return SignatureProcess.SignoffResult(operate, userID, userRole, schoolYear, schoolCode, actionType);

        }
        public static string SignatureOld(string operate, string userID, string userRole, string schoolYear, string schoolCode, string actionType, string actionDate)
        {
            try
            {
                ParameterSP1 parameter = new ParameterSP1 { Operate = operate, UserID = userID, UserRole = userRole, SchoolYear = schoolYear, SchoolCode = schoolCode, ActionType = actionType, ActionDate = actionDate };
                return GeneralDataAccess.TextValue(sp, parameter);
              //  return SignatureProcess.SignoffResult(operate, userID, userRole, schoolYear, schoolCode, actionType, actionDate);
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
        public static string Signature2(string operate, string userID, string schoolYear, string schoolCode, string actionType)
        {
            Signature parameter = new Signature { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode, ActionType = actionType };
            
            return GeneralDataAccess.TextValue(sp, parameter);

            // return SignatureProcess.SignoffResult(operate, userID, userRole, schoolYear, schoolCode, actionType);

        }
        public static string Signature2(string operate, string userID,  string schoolYear, string schoolCode, string actionType, string actionDate)
        {
            try
            {
                Signature parameter = new Signature { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode, ActionType = actionType, ActionDate = actionDate };
                sp = "dbo.tcdsb_PLF_Form_SignOffNew @Operate,@UserID,@SchoolYear,@SchoolCode,@ActionType,@ActionDate";
                return GeneralDataAccess.TextValue(sp, parameter);
                //  return SignatureProcess.SignoffResult(operate, userID, userRole, schoolYear, schoolCode, actionType, actionDate);
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
    }
}
