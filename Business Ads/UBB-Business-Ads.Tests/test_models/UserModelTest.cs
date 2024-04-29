// <copyright file="UserModelTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.Test_models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Backend.Models;
    using NUnit;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class UserModelTest
    {
        [Test]
        public void UserModel_GettingAndSettingProperties_SuccessGettingAndSettingPropertiesForUser()
        {
            // Arrange
            User mockUserToTest = new User();

            // Act
            mockUserToTest.Username = "testUser";
            mockUserToTest.Email = "testUser@email.test";
            mockUserToTest.Password = "testUserPassword";

            // Assert
            Assert.That(mockUserToTest.Username, Is.EqualTo("testUser"));
            Assert.That(mockUserToTest.Email, Is.EqualTo("testUser@email.test"));
            Assert.That(mockUserToTest.Password, Is.EqualTo("testUserPassword"));
        }
    }
}
