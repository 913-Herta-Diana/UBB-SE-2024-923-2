// <copyright file="UserController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Controllers
{
    using Backend.Models;

    public class UserController
    {
        private readonly List<User> users;

        public UserController()
        {
            this.users = new List<User>
            {
                new () { Username = "user1", Password = "pass1", Email = "user1@example.com" },
                new () { Username = "user2", Password = "pass2", Email = "user2@example.com" },
            };
        }

        public bool ValidateUser(string username, string password, string email)
        {
            return this.users.Any(u => u.Username == username && u.Email == email && u.Password == password);
        }
    }
}
