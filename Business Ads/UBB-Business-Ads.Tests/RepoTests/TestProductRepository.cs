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
        }

        [Fact]
        public void Set_WhenAssigningAProductToAnotherOne_ShouldUpdateAllAttributes()
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
            this.productRepository.Product = this.product;
            
            Assert.NotNull(this.productRepository.Product);
            Xunit.Assert.Equivalent(this.productRepository.Product, product);
          
        }

        [Fact]
        public void Get_WhenDecryptingProduct_ShouldContainInitialValuesAsAttributes()
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

            this.productRepository.Product = this.product;

            
            var decryptedProduct = this.productRepository.Product;

            
            Assert.NotNull(decryptedProduct);
            Assert.Equivalent(product, decryptedProduct);

        }

     
    }

}
