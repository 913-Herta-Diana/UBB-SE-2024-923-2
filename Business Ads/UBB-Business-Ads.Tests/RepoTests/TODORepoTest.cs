using Backend.Models;
using Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UBB_Business_Ads.Tests.RepoTests
{
    using NUnit;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;
    using Moq;

    [TestFixture]
    public class TODORepoTest
    {
        private TODORepository _TODOrepository;

        [SetUp]
        public void Setup()
        {
            _TODOrepository = new TODORepository();
        }
        [Test]
        public void Test_GetTODOS()
        {
            var result = _TODOrepository.GetTODOS();
            int expectedCount = _TODOrepository.GetTODOS().Count;
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(expectedCount));
        }
        [Test]
        public void Test_AddTODOS()
        {
            int initialTODOsCount= _TODOrepository.GetTODOS().Count;
            var newTODOtoAdd=new TODOClass("New task");
            _TODOrepository.AddingTODO(newTODOtoAdd);
            var todosList = _TODOrepository.GetTODOS(); 
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
            _TODOrepository.AddingTODO(newTODOtoRemove);
            _TODOrepository.AddingTODO(newTODOtoAdd);
            int initialTODOsCount = _TODOrepository.GetTODOS().Count;
            _TODOrepository.RemovingTODO(newTODOtoRemove);

            var todosList = _TODOrepository.GetTODOS(); 
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
