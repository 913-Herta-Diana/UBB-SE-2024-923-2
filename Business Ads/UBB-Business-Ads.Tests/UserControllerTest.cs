// <copyright file="UserControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests
{
    using Backend.Controllers;

    [TestFixture]
    internal class UserControllerTest
    {
        [Test]
        public void Validate_User_ValidCredentials_ReturnsTrue()
        {
            var userController = new UserController();
            string username = "user1";
            string password = "pass1";
            string email = "user1@example.com";

            bool areCredentialsValid = userController.ValidateUser(username, password, email);
            Assert.That(areCredentialsValid, Is.EqualTo(true));
        }

        [Test]
        public void Validate_User_InvalidCredentials_ReturnsFalse()
        {
            var userController = new UserController();
            string username = "user3";
            string password = "pass3";
            string email = "user3@example.com";

            bool areCredentialsInvalid = userController.ValidateUser(username, password, email);

            Assert.That(areCredentialsInvalid, Is.EqualTo(false));
        }
    }
}
