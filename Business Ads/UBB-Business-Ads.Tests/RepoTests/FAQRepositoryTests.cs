// <copyright file="FAQRepositoryTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Tests
{
    using Backend.Models;
    using Backend.Repositories;
    using Backend.Services;
    using Xunit;

    public class FAQRepositoryTests
    {
        [Fact]
        public void GetFAQList_ReturnsNotNullList()
        {
            // Arrange
            var repository = new FakeFAQRepository();

            // Act
            var faqList = repository.GetFAQList();

            // Assert
            Xunit.Assert.NotNull(faqList);
        }

        [Fact]
        public void AddFAQ_AddsFAQToRepository()
        {
            // Arrange
            var repository = new FakeFAQRepository();
            var faq = new FAQ();

            // Act
            repository.AddFAQ(faq);

            // Assert
            Xunit.Assert.Contains(faq, repository.GetFAQList());
        }

        [Fact]
        public void DeleteFAQ_RemovesFAQFromRepository()
        {
            // Arrange
            var repository = new FakeFAQRepository();
            var faq = new FAQ();
            repository.AddFAQ(faq);

            // Act
            repository.DeleteFAQ(faq);

            // Assert
            Xunit.Assert.DoesNotContain(faq, repository.GetFAQList());
        }
    }
}
