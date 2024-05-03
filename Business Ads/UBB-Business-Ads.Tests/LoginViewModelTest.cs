namespace UBB_Business_Ads.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Backend.Login;

    [TestFixture]
    internal class LoginViewModelTest
    {
        [Test]
        public void CanLogin_ValidCredentials_ReturnsTrue()
        {
            var loginViewModel = new LoginViewModel
            {
                Username = "user1",
                Password = "pass1",
                Email = "user1@example.com",
            };

            bool canLogin = loginViewModel.CanLogin();

            Assert.That(canLogin, Is.EqualTo(true));
        }

        [Test]
        public void CanLogin_InvalidCredentials_ReturnsFalse()
        {
            var loginViewModel = new LoginViewModel
            {
                Username = "user3",
                Password = "pass3",
                Email = "user3@example.com",
            };

            bool canLogin = loginViewModel.CanLogin();
            Assert.That(canLogin, Is.EqualTo(false));
        }
    }
}