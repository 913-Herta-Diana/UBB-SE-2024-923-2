// <copyright file="LoginViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Login
{
    using Backend.Controllers;

    public class LoginViewModel
    {
        private readonly UserController userService;

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public LoginViewModel()
        {
            this.userService = new UserController();
        }

        public bool CanLogin()
        {
            return this.userService.ValidateUser(this.Username, this.Password, this.Email);
        }
    }
}
