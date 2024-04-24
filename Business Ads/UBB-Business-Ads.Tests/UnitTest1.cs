using Backend.Models;
using Backend.Repositories;
using Backend.Services;
using Moq;
using NUnit;
using Xunit;
namespace UBB_Business_Ads.Tests
{
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
    }
}