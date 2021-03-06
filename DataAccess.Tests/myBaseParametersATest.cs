using myCommon;
// <copyright file="myBaseParametersATest.cs">Copyright ©  2017</copyright>

using System;
using DataAccess;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests
{
    /// <summary>This class contains parameterized unit tests for myBaseParametersA</summary>
    [TestClass]
    [PexClass(typeof(myBaseParametersA))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class myBaseParametersATest
    {

        /// <summary>Test stub for SetupBaseParameters(MyParameterDB[]&amp;, String, String, String, String, String)</summary>
        [PexMethod]
        public void SetupBaseParametersTest(
            ref MyParameterDB[] myPara,
            string userID,
            string _aID,
            string _cID,
            string _pID,
            string _iID
        )
        {
            myBaseParametersA.SetupBaseParameters(ref myPara, userID, _aID, _cID, _pID, _iID);
            // TODO: add assertions to method myBaseParametersATest.SetupBaseParametersTest(MyParameterDB[]&, String, String, String, String, String)
        }
    }
}
