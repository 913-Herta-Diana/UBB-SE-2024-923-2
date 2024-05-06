// <copyright file="UserControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests
{
    using Backend.Controllers;
    using Xunit;

    public class UserControllerTest
    {
        [Fact]
        public void IsUserInTheLoginList_CredentialsInTheList_ReturnsTrue()
        {
            var userController = new UserController();
            string username_to_test = "user1";
            string password_to_test = "pass1";
            string email_to_test = "user1@example.com";

            bool areCredentialsInTheList = userController.IsUserInTheLoginList(username_to_test, password_to_test, email_to_test);
            Assert.True(areCredentialsInTheList);
        }

        [Fact]
        public void IsUserInTheLoginList_CredentialsInTheList_ReturnsFalse()
        {
            var userController = new UserController();
            string username_to_test = "user3";
            string password_to_test = "pass3";
            string email_to_test = "user3@example.com";

            bool areCredentialsInTheList = userController.IsUserInTheLoginList(username_to_test, password_to_test, email_to_test);
            Assert.False(areCredentialsInTheList);
        }
    }
}
