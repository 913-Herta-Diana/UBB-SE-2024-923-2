namespace UBB_Business_Ads.Tests.RepoTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Pipes;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Reflection.Metadata.Ecma335;
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
            string constant = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<TODOs xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <TODOClass>\r\n    <Task>Review ad targeting strategies</Task>\r\n    <ID>0</ID>\r\n  </TODOClass>\r\n  <TODOClass>\r\n    <Task>Optimize ad campaign for higher conversion rates</Task>\r\n    <ID>1</ID>\r\n  </TODOClass>\r\n  <TODOClass>\r\n    <Task>Answer users</Task>\r\n    <ID>2</ID>\r\n  </TODOClass>\r\n  <TODOClass>\r\n    <Task>Check new questions</Task>\r\n    <ID>3</ID>\r\n  </TODOClass>\r\n  <TODOClass>\r\n    <Task>Test app</Task>\r\n    <ID>4</ID>\r\n  </TODOClass>\r\n</TODOs>";

            try
            {
                string binDirectory = "\\bin";
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                int index = basePath.IndexOf(binDirectory);
                string pathUntilBin = basePath.Substring(0, index);
                string pathToToDoXML = "\\XMLFiles\\TODOitems.xml";
                string xmlFilePath = pathUntilBin + pathToToDoXML;

                File.WriteAllText(xmlFilePath, constant);

                Console.WriteLine("XML file overwritten successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        [Fact]
        public void GetTODOS_WhenFetchingListOfTODOS_ShouldReturnTODOListSameNumberOfElements()
        {
            var result = this.repository.GetTODOS();
            Assert.NotNull(result);
            Assert.Equal(this.repository.GetTODOS().Count, result.Count());
        }


        [Fact]
        public void AddingTODO_WhenTODOelementIsAdded_ShouldAddElement()
        {
            var TODOelement = new TODOClass { Task = "Added task" };

            this.repository.AddingTODO(TODOelement);

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
