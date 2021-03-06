// <copyright file="UserProfileTest.cs">Copyright ©  2017</copyright>

using System;
using DataAccess;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests
{
    [TestClass]
    [PexClass(typeof(UserProfile))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class UserProfileTest
    {

        [PexMethod]
        public string UserLoginRole(string userId)
        {
            string result = UserProfile.UserLoginRole(userId);
            return result;
            // TODO: add assertions to method UserProfileTest.UserLoginRole(String)
        }
    }
}
