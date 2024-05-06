// <copyright file="TestProductRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.RepoTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Backend.Models;
    using Backend.Repositories;
    using Backend.Services;
    using Moq;
    using Xunit;

    public class TestProductRepository
    {
        private ProductMock product;
        private ProductRepository productRepository;

        public TestProductRepository()
        {
            this.productRepository = new ProductRepository(new ProductMock
            {
                Name = "Test Product",
                Description = "This is a test product",
                Price = "19.99",
                Image = "test.jpg",
            });

            this.product = new ProductMock
            {
                Name = "New Product",
                Description = "This is a new product",
                Price = "29.99",
                Image = "new.jpg",
            };
        }

        [Fact]
        public void Set_WhenAssigningAProductToAnotherOne_ShouldUpdateAllAttributes()
        {
            // Act
            this.productRepository.Product = this.product;

            // Assert
            Assert.NotNull(this.productRepository.Product);
            Assert.NotSame(this.product, this.productRepository.Product);
            Assert.Equal(this.product.Name, this.productRepository.Product.Name);
            Assert.Equal(this.product.Description, this.productRepository.Product.Description);
            Assert.Equal(this.product.Price, this.productRepository.Product.Price);
            Assert.Equal(this.product.Image, this.productRepository.Product.Image);
        }

        [Fact]
        public void Get_WhenDecryptingProduct_ShouldContainInitialValuesAsAttributes()
        {
            // Arrange
            this.productRepository.Product = this.product;

            // Act
            var decryptedProduct = this.productRepository.Product;

            // Assert
            Assert.NotNull(decryptedProduct);
            Assert.Equal("New Product", decryptedProduct.Name);
            Assert.Equal("This is a new product", decryptedProduct.Description);
            Assert.Equal("29.99", decryptedProduct.Price);
            Assert.Equal("new.jpg", decryptedProduct.Image);
        }

     
    }

}
