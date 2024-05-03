// <copyright file="UnitTest1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Backend.Models;
    using Backend.Repositories;
    using Backend.Services;
    using Moq;
    using NUnit;
    using NUnit.Framework.Legacy;
    using Xunit;

    public class Tests
    {
        [Test]
        public void Test1()
        {
            Xunit.Assert.True(true);
        }

        [TestFixture]
        public class DataEncryptionServiceTests
        {
            [Test]
            public void TestEncryptDecrypt()
            {
                // Arrange
                var dataEncryptionService = new DataEncryptionService();
                string originalData = "Hello, World!";

                // Act
                var encryptionResult = dataEncryptionService.Encrypt(originalData);
                string encryptedData = encryptionResult["data"];
                string key = encryptionResult["key"];
                string decryptedData = dataEncryptionService.Decrypt(encryptedData, key);


                Xunit.Assert.NotEqual(originalData, encryptedData); 
                Xunit.Assert.Equal(originalData, decryptedData); 
            }
        }
        public class DataDecryptionServiceTests
        {
            [Fact]
            public void Decrypt_LetterCharacter_ReturnsDecryptedCharacter()
            {
                // Arrange
                var dataEncryptionService = new DataEncryptionService();
                string data = "a";
                string key = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string expected = "a";

                // Act
                string actual = dataEncryptionService.Decrypt(data, key);

                // Assert
                Xunit.Assert.Equal(expected, actual);
            }

            [Fact]
            public void Decrypt_NonLetterCharacter_ReturnsOriginalCharacter()
            {
                // Arrange
                var dataEncryptionService = new DataEncryptionService();
                string data = " ";
                string key = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string expected = " ";

                // Act
                string actual = dataEncryptionService.Decrypt(data, key);

                // Assert
                Xunit.Assert.Equal(expected, actual);
            }

            [Fact]
            public void Decrypt_AllLettersInKey_ShouldDecryptCorrectly()
            {
                // Arrange
                var dataEncryptionService = new DataEncryptionService();
                string data = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string key = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

                // Act
                string actual = dataEncryptionService.Decrypt(data, key);

                // Assert
                Xunit.Assert.Equal(data, actual);
            }

            [Fact]
            public void Decrypt_AllNonLetterCharacters_ShouldReturnOriginalData()
            {
                // Arrange
                var dataEncryptionService = new DataEncryptionService();
                string data = "!@#$%^&*()_+-=[]{};':\",.<>/?1234567890";
                string key = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

                // Act
                string actual = dataEncryptionService.Decrypt(data, key);

                // Assert
                Xunit.Assert.Equal(data, actual);
            }
        }
        public class FAQServiceTests
        {
            [Fact]
            public void Instance_ReturnsSameInstance()
            {
                // Arrange
                var service1 = FAQService.Instance;
                var service2 = FAQService.Instance;

                // Assert
                Xunit.Assert.Same(service1, service2);
            }
            [Fact]
            public void Constructor_InitializesRepositoryAndSubmittedQuestions()
            {
                // Arrange & Act
                var service = new FAQService();

                // Assert
                Xunit.Assert.NotNull(service.GetAllFAQs()); // Verify that repository is initialized
                Xunit.Assert.NotNull(service.GetSubmittedQuestions()); // Verify that submittedQuestions list is initialized
                Xunit.Assert.Empty(service.GetSubmittedQuestions()); // Verify that submittedQuestions list is empty initially
            }
            [Fact]
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

            [Fact]
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
}