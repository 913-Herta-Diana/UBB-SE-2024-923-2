using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework.Legacy;
using NUnit.Framework;
using NUnit;
using Backend.Models;



namespace UBB_Business_Ads.Tests.test_models
{
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
