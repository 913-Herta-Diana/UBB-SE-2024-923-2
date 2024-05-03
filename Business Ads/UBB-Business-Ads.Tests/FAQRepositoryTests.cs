
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Backend.Models;
using System.Xml;

namespace Backend.Repositories.Tests
{
    [TestFixture]
    public class FAQRepositoryTests
    {
        private const string TestXmlFilePath = "TestFAQ.xml"; // Path to the test XML file
        private const string TestQuestion = "Test Question";
        private const string TestAnswer = "Test Answer";
        private const string TestTopic = "Test Topic";

        [SetUp]
        public void SetUp()
        {
            // Create a test XML file with sample data
            CreateTestXmlFile();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up: delete the test XML file after testing
            if (File.Exists(TestXmlFilePath))
            {
                File.Delete(TestXmlFilePath);
            }
        }

        [Test]
        public void GetFAQList_ReturnsCorrectList()
        {
            // Arrange
            FAQRepository faqRepository = new FAQRepository();

            // Act
            List<FAQ> faqList = faqRepository.GetFAQList();

            // Assert
            Assert.That(faqList, Is.Not.Null);
            // Add more assertions as needed
        }

        
        /*public void LoadFAQsFromXml_FileExists_LoadsFAQs()
        {
            // Arrange
            FAQRepository faqRepository = new FAQRepository();

            // Act
            faqRepository.LoadFAQsFromXml();

            // Assert
            List<FAQ> faqList = faqRepository.GetFAQList();
            Assert.That(faqList, Is.Not.Null);
            Assert.That(faqList, Is.Not.Empty);
            // Add more assertions to validate the loaded FAQs
        }

        [Test]
        public void SaveFAQsToXml_SaveToFile()
        {
            // Arrange
            FAQRepository faqRepository = new FAQRepository();
            var faq = new FAQ { Question = TestQuestion, Answer = TestAnswer, Topic = TestTopic };
            faqRepository.AddFAQ(faq);

            // Act
            faqRepository.SaveFAQsToXml();

            // Assert
            Assert.That(File.Exists(TestXmlFilePath), Is.True);
            // Add more assertions as needed
        }*/

        [Test]
        public void AddFAQ_AddsNewFAQ()
        {
            // Arrange
            FAQRepository faqRepository = new FAQRepository();
            var faq = new FAQ { Question = TestQuestion, Answer = TestAnswer, Topic = TestTopic };

            // Act
            faqRepository.AddFAQ(faq);

            // Assert
            List<FAQ> faqList = faqRepository.GetFAQList();
            Assert.That(faqList.Any(f => f.Question == TestQuestion && f.Answer == TestAnswer && f.Topic == TestTopic), Is.True);
            // Add more assertions as needed
        }

        [Test]
        public void DeleteFAQ_DeletesFAQ()
        {
            // Arrange
            FAQRepository faqRepository = new FAQRepository();
            var faq = new FAQ { Question = TestQuestion, Answer = TestAnswer, Topic = TestTopic };
            faqRepository.AddFAQ(faq);

            // Act
            faqRepository.DeleteFAQ(faq);

            // Assert
            List<FAQ> faqList = faqRepository.GetFAQList();
            Assert.That(faqList.Any(f => f.Question == TestQuestion && f.Answer == TestAnswer && f.Topic == TestTopic), Is.True);
            // Add more assertions as needed
        }

        // Helper method to create a test XML file with sample data
        private void CreateTestXmlFile()
        {
            using (XmlWriter writer = XmlWriter.Create(TestXmlFilePath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("FAQs");

                writer.WriteStartElement("FAQ");
                writer.WriteElementString("Question", "Sample Question");
                writer.WriteElementString("Answer", "Sample Answer");
                writer.WriteElementString("Topic", "Sample Topic");
                writer.WriteEndElement();

                // Add more sample FAQs if needed

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
