using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessOperation
{
    public class ReportPrint
    {
        public static void RenderPDF(string reportName, string userID, string schoolYear, string schoolCode, string publishCycle)
        {
            Byte[] pdfReport = ReportRender.GetOneReport(reportName, userID, schoolYear, schoolCode, publishCycle);

            string rFormat = WebConfig.ReportFormat();
            ReportRender.RenderReport(reportName, rFormat, pdfReport);
        }
    }
}
