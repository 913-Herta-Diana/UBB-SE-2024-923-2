// <copyright file="TODOServices.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Services
{
    using Backend.Models;
    using Backend.Repositories;

    public class TODOServices : IServicesTODO
    {
        private static readonly TODOServices TheInstance = new ();
        private readonly TODORepository repository;

        private TODOServices()
        {
            this.repository = new TODORepository();
        }

        public static TODOServices Instance
        {
            get { return TheInstance; }
        }

        public List<TODOClass> GetTODOS()
        {
            return this.repository.GetTODOS();
        }

        public void AddTODO(TODOClass obj)
        {
            this.repository.AddingTODO(obj);
        }

        public void RemoveTODO(int id)
        {
            TODOClass todoToRemove = this.GetTODOS().FirstOrDefault(todo => todo.ID == id);

            if (todoToRemove != null)
            {
                this.repository.RemovingTODO(todoToRemove);
            }
        }
    }
}
