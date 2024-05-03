// <copyright file="TODORepoTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.RepoTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using Backend.Models;
    using Backend.Repositories;
    using Moq;
    using NUnit;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class TODORepoTest
    {
        private TODORepository tODOrepository;

        [SetUp]
        public void Setup()
        {
            this.tODOrepository = new TODORepository();
        }

        [Test]
        public void Test_GetTODOS()
        {
            var result = this.tODOrepository.GetTODOS();
            int expectedCount = this.tODOrepository.GetTODOS().Count;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(expectedCount));
        }

        [Test]
        public void Test_AddTODOS()
        {
            int initialTODOsCount = this.tODOrepository.GetTODOS().Count;
            var newTODOtoAdd = new TODOClass("New task");
            this.tODOrepository.AddingTODO(newTODOtoAdd);
            var todosList = this.tODOrepository.GetTODOS();
            var updatedTodosCount = todosList.Count;

            Assert.Multiple(() =>
            {
                Assert.That(updatedTodosCount, Is.EqualTo(initialTODOsCount + 1));
                Assert.That(todosList, Does.Contain(newTODOtoAdd));
            });
        }

        [Test]
        public void Test_RemoveTODOS()
        {
            var newTODOtoRemove = new TODOClass("Remove this task");
            var newTODOtoAdd = new TODOClass("Keep this task");
            this.tODOrepository.AddingTODO(newTODOtoRemove);
            this.tODOrepository.AddingTODO(newTODOtoAdd);
            int initialTODOsCount = this.tODOrepository.GetTODOS().Count;
            this.tODOrepository.RemovingTODO(newTODOtoRemove);

            var todosList = this.tODOrepository.GetTODOS();
            var updatedTodosCount = todosList.Count;

            Assert.Multiple(() =>
            {
                Assert.That(updatedTodosCount, Is.EqualTo(initialTODOsCount - 1));
                Assert.That(todosList, Does.Not.Contain(newTODOtoRemove));
                Assert.That(todosList, Does.Contain(newTODOtoAdd));
            });
        }
    }
}
