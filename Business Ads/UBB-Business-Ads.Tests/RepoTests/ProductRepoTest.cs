/*using Backend.Models;
using Backend.Repositories;
using Backend.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBB_Business_Ads.Tests.RepoTests
{
    [TestFixture]
    public class ProductRepoTest
    {
        *//*[Test]
        public void Product_Set_EncryptsAndSetsProductProperties()
        {
            // Arrange
            var prod= new ProductMock();
            var repository = new ProductRepository(prod); // Initialize with null product
*/
            /*var originalProduct = new ProductMock
            {
                Name = "OriginalName",
                Description = "OriginalDescription",
                Price = "OriginalPrice",
                Image = "OriginalImage"
            };

            // Mock DataEncryptionService
            var encryptionServiceMock = new Mock<DataEncryptionService>();

            // Mock encryption results
            var encryptedNameKeyValuePair = new Dictionary<string, string>
            {
                { "data", "EncryptedName" },
                { "key", "NameKey" }
            };

            var encryptedDescriptionKeyValuePair = new Dictionary<string, string>
            {
                { "data", "EncryptedDescription" },
                { "key", "DescriptionKey" }
            };

            var encryptedPriceKeyValuePair = new Dictionary<string, string>
            {
                { "data", "EncryptedPrice" },
                { "key", "PriceKey" }
            };

            var encryptedImageKeyValuePair = new Dictionary<string, string>
            {
                { "data", "EncryptedImage" },
                { "key", "ImageKey" }
            };

            encryptionServiceMock.Setup(e => e.Encrypt(originalProduct.Name)).Returns(encryptedNameKeyValuePair);
            encryptionServiceMock.Setup(e => e.Encrypt(originalProduct.Description)).Returns(encryptedDescriptionKeyValuePair);
            encryptionServiceMock.Setup(e => e.Encrypt(originalProduct.Price)).Returns(encryptedPriceKeyValuePair);
            encryptionServiceMock.Setup(e => e.Encrypt(originalProduct.Image)).Returns(encryptedImageKeyValuePair);

            // Act
            repository.Product = originalProduct;*//*
        }
    }


*/