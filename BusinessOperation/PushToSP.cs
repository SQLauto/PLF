using ClassLibrary;
using DataAccess;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessOperation
{
    public class PushToSP
    {
        static string sp = "dbo.tcdsb_PLF_Form_SignOffNew @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@ActionType";

        public static string Signature(string operate, string userID, string userRole, string schoolYear, string schoolCode, string actionType)
        {
            ParameterSP1 parameter = new ParameterSP1 { Operate = operate, UserID = userID, UserRole = userRole, SchoolYear = schoolYear, SchoolCode = schoolCode, ActionType = actionType };
            return GeneralDataAccess.TextValue(sp, parameter);

            // return SignatureProcess.SignoffResult(operate, userID, userRole, schoolYear, schoolCode, actionType);

        }
        public static string Signature(string operate, string userID, string userRole, string schoolYear, string schoolCode, string actionType, string actionDate)
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
        public static void SaveFileToHistoryFolder(string schoolYear, string fileName, byte[] imageData)
            {
            string filePath = WebConfig.getValuebyKey("SLIPHistoryPath") + "\\" + schoolYear + "\\";

            fileName = filePath + fileName;
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }
                System.IO.FileStream objFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create);

                System.IO.BinaryWriter objBinaryWriter = new System.IO.BinaryWriter(objFileStream);
                objBinaryWriter.Write(imageData);
                objBinaryWriter.Close();
                objFileStream.Close();
            }
            catch (Exception exp)
            { var em = exp.Message; }

        }
        public static string PublishPLFtoSharePointSite(string type, byte[] result, string schoolYear, string schoolCode, string schoolName, string schoolNameB)
        {
            return UploadFileToSharePointSite.PushToSite("SLIP", result, schoolYear, schoolCode, schoolName, schoolNameB);
        }
    }
}
