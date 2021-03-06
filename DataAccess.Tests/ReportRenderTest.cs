using System.Reflection;
using myCommon;
// <copyright file="ReportRenderTest.cs">Copyright ©  2017</copyright>

using System;
using DataAccess;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests
{
    [TestClass]
    [PexClass(typeof(ReportRender))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ReportRenderTest
    {

        [PexMethod]
        public void setParameterArray(
            MyParameterRS[] _ParaArray,
            int X,
            string _Name,
            string _Value
        )
        {
            ReportRender.setParameterArray(_ParaArray, X, _Name, _Value);
            // TODO: add assertions to method ReportRenderTest.setParameterArray(MyParameterRS[], Int32, String, String)
        }

        [PexMethod]
        public void RenderReport(string _reportName, MyParameterRS[] _reportParameter)
        {
            ReportRender.RenderReport(_reportName, _reportParameter);
            // TODO: add assertions to method ReportRenderTest.RenderReport(String, MyParameterRS[])
        }

        [PexMethod(MaxBranches = 20000)]
        public byte[] GetReportR2(string _reportName, MyParameterRS[] _reportParameter)
        {
            byte[] result = ReportRender.GetReportR2(_reportName, _reportParameter);
            return result;
            // TODO: add assertions to method ReportRenderTest.GetReportR2(String, MyParameterRS[])
        }

        [PexMethod]
        [PexAllowedException(typeof(NullReferenceException))]
        public byte[] MultiplePDF(
            string[] mySelectIDArray,
            string reportName,
            string schoolyear,
            string schoolcode,
            string sessionID
        )
        {
            byte[] result
               = ReportRender.MultiplePDF(mySelectIDArray, reportName, schoolyear, schoolcode, sessionID);
            return result;
            // TODO: add assertions to method ReportRenderTest.MultiplePDF(String[], String, String, String, String)
        }

        [PexMethod(MaxBranches = 20000)]
        [PexMethodUnderTest("GetOneReport(String, String, String, String, String, String)")]
        internal byte[] GetOneReport(
            string reportName,
            string userID,
            string schoolyear,
            string schoolcode,
            string sessionID,
            string employeeID
        )
        {
            object[] args = new object[6];
            args[0] = (object)reportName;
            args[1] = (object)userID;
            args[2] = (object)schoolyear;
            args[3] = (object)schoolcode;
            args[4] = (object)sessionID;
            args[5] = (object)employeeID;
            Type[] parameterTypes = new Type[6];
            parameterTypes[0] = typeof(string);
            parameterTypes[1] = typeof(string);
            parameterTypes[2] = typeof(string);
            parameterTypes[3] = typeof(string);
            parameterTypes[4] = typeof(string);
            parameterTypes[5] = typeof(string);
            byte[] result0 = ((MethodBase)(typeof(ReportRender).GetMethod("GetOneReport",
                                                                          BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.NonPublic, (Binder)null,
                                                                          CallingConventions.Standard, parameterTypes, (ParameterModifier[])null)))
                                 .Invoke((object)null, args) as byte[];
            byte[] result = result0;
            return result;
            // TODO: add assertions to method ReportRenderTest.GetOneReport(String, String, String, String, String, String)
        }
    }
}
