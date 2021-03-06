using myCommon;
// <copyright file="myBaseParametersBTest.cs">Copyright ©  2017</copyright>

using System;
using DataAccess;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests
{
    [TestClass]
    [PexClass(typeof(myBaseParametersB))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class myBaseParametersBTest
    {

        [PexMethod]
        public void SetupBaseParameters(
            ref MyParameterDB[] myPara,
            string operate,
            string userID,
            string categoryID,
            string areaID,
            string itemCode
        )
        {
            myBaseParametersB.SetupBaseParameters(ref myPara, operate, userID, categoryID, areaID, itemCode);
            // TODO: add assertions to method myBaseParametersBTest.SetupBaseParameters(MyParameterDB[]&, String, String, String, String, String)
        }
    }
}
