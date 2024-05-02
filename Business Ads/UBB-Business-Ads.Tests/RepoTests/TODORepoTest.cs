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
        private TODORepository _TODOrepo;

        [SetUp]
        public void Setup()
        {
            _TODOrepo = new TODORepository();
        }
        [Test]
        public void Test_GetTODOS()
        {
            var result = _TODOrepo.getTODOS();
            var expectedCount = _TODOrepo.getTODOS().Count();
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(expectedCount));
        }
        [Test]
        public void Test_AddTODOS()
        {
            int initialTODOsCount=_TODOrepo.getTODOS().Count();
            var newTODO=new TODOClass("New task");
            _TODOrepo.addingTODO(newTODO);
            var todosList = _TODOrepo.getTODOS(); 
            var updatedTodosCount = todosList.Count;

            Assert.That(updatedTodosCount, Is.EqualTo(initialTODOsCount + 1));
            Assert.That(todosList.Contains(newTODO), Is.True);

        }

        [Test]
        public void Test_RemoveTODOS()
        {
           
            var newTODO1 = new TODOClass("Remove this task");
            var newTODO2 = new TODOClass("Keep this task");
            _TODOrepo.addingTODO(newTODO1);
            _TODOrepo.addingTODO(newTODO2);
            int initialTODOsCount = _TODOrepo.getTODOS().Count();
            _TODOrepo.removingTODO(newTODO1);

            var todosList = _TODOrepo.getTODOS(); 
            var updatedTodosCount = todosList.Count;

           Assert.That(updatedTodosCount, Is.EqualTo(initialTODOsCount -1));
            Assert.That(todosList.Contains(newTODO1), Is.False);
            Assert.That(todosList.Contains(newTODO2), Is.True);

        }

    }
}
