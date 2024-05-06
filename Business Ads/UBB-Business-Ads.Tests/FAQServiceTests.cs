// <copyright file="FAQServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
// <summary>
//   This file contains unit tests for the FAQService class.
// </summary>
// <copyright>
//   Copyright (c) [year] [author's name]. All rights reserved.
// </copyright>
// <author>
//   [author's name]
// </author>
//-----------------------------------------------------------------------
namespace UBB_Business_Ads.Tests
{
    using Backend.Models;
    using Backend.Services;

    [TestFixture]
    public class FaqServiceTests
    {
        [Test]
        public void Instance_ReturnsSameInstance()
        {
            // Arrange
            var service1 = FAQService.Instance;
            var service2 = FAQService.Instance;

            // Assert
            Xunit.Assert.Same(service1, service2);
        }

        [Test]

        public void Constructor_InitializesRepositoryAndSubmittedQuestions()
        {
            // Arrange & Act
            var service = new FAQService();

            // Assert
            Xunit.Assert.NotNull(service.GetAllFAQs()); // Verify that repository is initialized
            Xunit.Assert.NotNull(service.GetSubmittedQuestions()); // Verify that submittedQuestions list is initialized
            Xunit.Assert.Empty(service.GetSubmittedQuestions()); // Verify that submittedQuestions list is empty initially
        }

        [Test]

        public void AddSubmittedQuestion_AddsNewQuestionToSubmittedQuestionsList()
        {
            // Arrange
            var service = new FAQService();
            var newQuestion = new FAQ { Question = "Test question", Answer = "Test answer" };

            // Act
            service.AddSubmittedQuestion(newQuestion);
            var submittedQuestions = service.GetSubmittedQuestions();

            // Assert
            Xunit.Assert.Contains(newQuestion, submittedQuestions);
        }

        [Test]

        public void GetSubmittedQuestions_ReturnsSubmittedQuestionsList()
        {
            // Arrange
            var service = new FAQService();
            var newQuestion1 = new FAQ { Question = "Test question 1", Answer = "Test answer 1" };
            var newQuestion2 = new FAQ { Question = "Test question 2", Answer = "Test answer 2" };
            service.AddSubmittedQuestion(newQuestion1);
            service.AddSubmittedQuestion(newQuestion2);

            // Act
            var result = service.GetSubmittedQuestions();

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(2, result.Count);
            Xunit.Assert.Contains(newQuestion1, result);
            Xunit.Assert.Contains(newQuestion2, result);
        }
    }
}