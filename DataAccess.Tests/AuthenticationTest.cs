// <copyright file="AuthenticationTest.cs">Copyright ©  2017</copyright>

using System;
using DataAccess;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests
{
    [TestClass]
    [PexClass(typeof(Authentication))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AuthenticationTest
    {

        [PexMethod]
        public string UserRole(string userID)
        {
            string result = Authentication.UserRole(userID);
            return result;
            // TODO: add assertions to method AuthenticationTest.UserRole(String)
        }
    }
}
