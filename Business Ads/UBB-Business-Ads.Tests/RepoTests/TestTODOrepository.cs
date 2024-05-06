namespace UBB_Business_Ads.Tests.RepoTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Backend.Models;
    using Backend.Repositories;
    using Xunit;

    public class TestTODOrepository: IDisposable
    {
        private TODORepository repository;

        public TestTODOrepository() { 
        
            repository = new TODORepository();

        }

        public void Dispose()
        {



        }

        [Fact]
        public void GetTODOS_WhenFetchingListOfTODOS_ShouldReturnTODOListSameNumberOfElements()
        {
            var result=repository.GetTODOS();
            Assert.NotNull(result);
            Assert.Equal(repository.GetTODOS().Count, result.Count());
        }


        [Fact]
        public void AddingTODO_WhenTODOelementIsAdded_ShouldAddElement()
        {
            var TODOelement = new TODOClass("Added task");

            repository.AddingTODO(TODOelement);

            Assert.Contains(TODOelement, repository.GetTODOS());

        }
        [Fact]
        public void RemovingTODO_WhenTODOelementIsRemoved_ShouldRemoveElement()
        {
            var TODOelement = new TODOClass("To be removed task");

            repository.AddingTODO(TODOelement);
            

            repository.RemovingTODO(TODOelement);

            Assert.DoesNotContain(TODOelement, repository.GetTODOS());
        }

    }
}
