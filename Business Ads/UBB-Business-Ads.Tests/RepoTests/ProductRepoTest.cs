using Backend.Models;
using Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UBB_Business_Ads.Tests.RepoTests
{
    using NUnit;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;
    using Moq;
    using Backend.Services;

    [TestFixture]
    public class ProductRepoTest
    {
        private ProductRepository _productRepo;

        [SetUp]
        public void Setup()
        {
            var _productMock = new ProductMock();
            var _productRepo = new ProductRepository(_productMock);
        }
/*
        [Test]
        public void Test_GetProduct()

        {
            var encryptionService = new DataEncryptionService();
            var repository = new ProductRepository(null); // We'll pass null initially, as we'll set it later

           *//* var updatedProduct = new ProductMock
            {
                Name = "NewName",
                Description = "NewDescription",
                Price = "NewPrice",
                Image = "NewImage"
            };*//*
        }*//**/

    }
}

