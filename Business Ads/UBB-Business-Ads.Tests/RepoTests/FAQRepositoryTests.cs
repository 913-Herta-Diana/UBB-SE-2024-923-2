using Backend.Models;
using Backend.Repositories;
using Backend.Services;
using Moq;
using Xunit;

namespace Backend.Tests
{
    public class FAQRepositoryTests
    {
        [Fact]
        public void GetFAQList_ReturnsFAQList()
        {
            // Arrange
            var fileIOServiceMock = new Mock<IFileIOService>();
            var repository = new FAQRepository(fileIOServiceMock.Object);

            // Act
            var faqList = repository.GetFAQList();

            // Assert
            Assert.NotNull(faqList);
        }

        [Fact]
        public void AddFAQ_AddsFAQToList()
        {
            // Arrange
            var fileIOServiceMock = new Mock<IFileIOService>();
            var repository = new FAQRepository(fileIOServiceMock.Object);
            var faq = new FAQ();

            // Act
            repository.AddFAQ(faq);

            // Assert
            Assert.Contains(faq, repository.GetFAQList());
        }

        [Fact]
        public void DeleteFAQ_RemovesFAQFromList()
        {
            // Arrange
            var fileIOServiceMock = new Mock<IFileIOService>();
            var repository = new FAQRepository(fileIOServiceMock.Object);
            var faq = new FAQ();
            repository.AddFAQ(faq);

            // Act
            repository.DeleteFAQ(faq);

            // Assert
            Assert.DoesNotContain(faq, repository.GetFAQList());
        }
    }
}