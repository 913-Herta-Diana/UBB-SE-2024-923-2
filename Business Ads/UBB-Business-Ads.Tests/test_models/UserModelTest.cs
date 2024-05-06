// <copyright file="UserModelTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace UBB_Business_Ads.Tests.Test_models
{
    using Backend.Models;

    [TestFixture]
    internal class UserModelTest
    {
        /// <summary>
        /// Test to ensure that user properties are set correctly.
        /// </summary>
        [Test]
        public void User_GettingAndSettingProperties_SuccessGettingAndSettingForUser()
        {
            string username_to_test = "testuser";
            string password_to_test = "testpass";
            string email_to_test = "testuser@example.com";

            var user_to_test = new User
            {
                Username = username_to_test,
                Password = password_to_test,
                Email = email_to_test,
            };

            Assert.Multiple(() =>
            {
                Assert.That(user_to_test, Has.Property(nameof(User.Username)).EqualTo(username_to_test)
                                   .And.Property(nameof(User.Email)).EqualTo(email_to_test)
                                   .And.Property(nameof(User.Password)).EqualTo(password_to_test));
            });
        }
    }
}