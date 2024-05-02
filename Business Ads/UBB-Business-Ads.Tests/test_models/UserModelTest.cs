// <copyright file="UserModelTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

<<<<<<< HEAD
using NUnit.Framework.Legacy;
using NUnit.Framework;
using NUnit;
using Backend.Models;



=======
>>>>>>> 73c7dcf1d614218690855e9718433ee33c30eab2
namespace UBB_Business_Ads.Tests.Test_models
{
    using Backend.Models;

    [TestFixture]
    internal class UserModelTest
    {
        [Test]
        public void User_PropertiesAreSetCorrectly()
        {
            string username = "testuser";
            string password = "testpass";
            string email = "testuser@example.com";

            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
            };
            Assert.That(user.Username, Is.EqualTo(username));
            Assert.That(user.Email, Is.EqualTo(email));
            Assert.That(user.Password, Is.EqualTo(password));
        }
    }
}
