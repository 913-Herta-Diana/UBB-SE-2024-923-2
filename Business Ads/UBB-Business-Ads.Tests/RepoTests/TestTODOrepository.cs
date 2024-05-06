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
            File.WriteAllText("C:\\Users\\herta\\Desktop\\Sem4\\Biznis\\Business Ads\\UBB-Business-Ads.Tests\\XMLfiles\\TODOitems.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<TODOs xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n\t<TODOClass>\r\n\t\t<Task>Review ad targeting strategies</Task>\r\n\t\t<ID>0</ID>\r\n\t</TODOClass>\r\n\t<TODOClass>\r\n\t\t<Task>Optimize ad campaign for higher conversion rates</Task>\r\n\t\t<ID>1</ID>\r\n\t</TODOClass>\r\n\t<TODOClass>\r\n\t\t<Task>Answer users</Task>\r\n\t\t<ID>2</ID>\r\n\t</TODOClass>\r\n\t<TODOClass>\r\n\t\t<Task>Check new questions</Task>\r\n\t\t<ID>3</ID>\r\n\t</TODOClass>\r\n</TODOs>");

            //repository.GetTODOS();
            
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
