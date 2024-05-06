// <copyright file="INterfaceProductRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using Backend.Models;
    using Backend.Services;

    public class ProductRepository : INterfaceProductRepository
    {
        private readonly DataEncryptionService encryptionService = new ();
        private Product product;
        private string nameKey;
        private string descriptionKey;
        private string priceKey;
        private string imageKey;

        public ProductRepository(Product product)
        {
            this.Product = product;
        }

        public Product Product
        {
            get
            {
                string decryptedName = this.encryptionService.Decrypt(this.product.Name, this.nameKey);
                string decryptedDescription = this.encryptionService.Decrypt(this.product.Description, this.descriptionKey);
                string decryptedPrice = this.encryptionService.Decrypt(this.product.Price, this.priceKey);
                string decryptedImage = this.encryptionService.Decrypt(this.product.Image, this.imageKey);
                return new Product
                {
                    Name = decryptedName,
                    Description = decryptedDescription,
                    Price = decryptedPrice,
                    Image = decryptedImage,
                };
            }

            set
            {
                Dictionary<string, string> encryptedNameKeyValuePair = this.encryptionService.Encrypt(value.Name);
                string encryptedName = encryptedNameKeyValuePair["data"];
                this.nameKey = encryptedNameKeyValuePair["key"];
                Dictionary<string, string> encryptedDescriptionKeyValuePair = this.encryptionService.Encrypt(value.Description);
                string encryptedDescription = encryptedDescriptionKeyValuePair["data"];
                this.descriptionKey = encryptedDescriptionKeyValuePair["key"];
                Dictionary<string, string> encryptedPriceKeyValuePair = this.encryptionService.Encrypt(value.Price);
                string encryptedPrice = encryptedPriceKeyValuePair["data"];
                this.priceKey = encryptedPriceKeyValuePair["key"];
                Dictionary<string, string> encryptedImageKeyValuePair = this.encryptionService.Encrypt(value.Image);
                string encryptedImage = encryptedImageKeyValuePair["data"];
                this.imageKey = encryptedImageKeyValuePair["key"];
                this.product = new Product
                {
                    Name = encryptedName,
                    Description = encryptedDescription,
                    Price = encryptedPrice,
                    Image = encryptedImage,
                };
            }
        }
    }
}
