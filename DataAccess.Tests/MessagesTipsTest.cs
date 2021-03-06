// <copyright file="MessagesTipsTest.cs">Copyright ©  2017</copyright>

using System;
using DataAccess;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests
{
    [TestClass]
    [PexClass(typeof(MessagesTips))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MessagesTipsTest
    {

        [PexMethod]
        public string Message(
            string _aID,
            string _cID,
            string _pID,
            string _iID
        )
        {
            string result = MessagesTips.Message(_aID, _cID, _pID, _iID);
            return result;
            // TODO: add assertions to method MessagesTipsTest.Message(String, String, String, String)
        }
    }
}
