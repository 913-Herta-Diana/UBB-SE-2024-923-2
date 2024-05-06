// <copyright file="DataEncryptionServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
// <summary>
//   This file contains unit tests for the DataEncryptionService class.
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
    using Backend.Services;

    [TestFixture]
    public class DataEncryptionServiceTests
    {
        [Test]
        public void Encrypt_WhenGivenValidData_ReturnsDecryptedData()
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

        [Test]

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

        [Test]

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

        [Test]

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

        [Test]

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
}
