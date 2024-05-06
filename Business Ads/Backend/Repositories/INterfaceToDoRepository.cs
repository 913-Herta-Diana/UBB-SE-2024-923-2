// <copyright file="TODORepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using Backend.Models;

    internal interface INterfaceToDoRepository
    {
        public void AddingTODO(TODOClass newTODO);

        public void RemovingTODO(TODOClass newTODO);

        public List<TODOClass> GetTODOS();
    }
}
