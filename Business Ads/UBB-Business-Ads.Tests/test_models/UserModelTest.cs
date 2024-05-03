// <copyright file="UserModelTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using Backend.Models;

namespace UBB_Business_Ads.Tests.Test_models
{
    [TestFixture]
    internal class UserModelTest
    {
        /// <summary>
        /// Test to ensure that user properties are set correctly.
        /// </summary>
        [Test]
        public void User_GettingAndSettingProperties_SuccessGettingAndSettingForUser()
        {
            // Arrange
            string username = "testuser";
            string password = "testpass";
            string email = "testuser@example.com";

            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
            };

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(user, Has.Property(nameof(User.Username)).EqualTo(username)
                                   .And.Property(nameof(User.Email)).EqualTo(email)
                                   .And.Property(nameof(User.Password)).EqualTo(password));
            });
        }
    }
}

