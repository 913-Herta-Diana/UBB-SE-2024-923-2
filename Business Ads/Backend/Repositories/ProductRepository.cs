using Backend.Models;
using Backend.Services;

namespace Backend.Repositories
{
    public class ProductRepository
    {
        private DataEncryptionService encryptionService = new DataEncryptionService();
        private ProductMock _product;
        private string _nameKey;
        private string _descriptionKey;
        private string _priceKey;
        private string _imageKey;

        public ProductMock Product
        {
            get
            {
                string decryptedName = encryptionService.Decrypt(_product.Name, _nameKey);
                string decryptedDescription = encryptionService.Decrypt(_product.Description, _descriptionKey);
                string decryptedPrice = encryptionService.Decrypt(_product.Price, _priceKey);
                string decryptedImage = encryptionService.Decrypt(_product.Image, _imageKey);
                return new ProductMock
                {
                    Name = decryptedName,
                    Description = decryptedDescription,
                    Price = decryptedPrice,
                    Image = decryptedImage
                };
            }
            set
            {
                Dictionary<string, string> encryptedNameKeyValuePair = encryptionService.Encrypt(value.Name);
                string encryptedName = encryptedNameKeyValuePair["data"];
                _nameKey = encryptedNameKeyValuePair["key"];
                Dictionary<string, string> encryptedDescriptionKeyValuePair = encryptionService.Encrypt(value.Description);
                string encryptedDescription = encryptedDescriptionKeyValuePair["data"];
                _descriptionKey = encryptedDescriptionKeyValuePair["key"];
                Dictionary<string, string> encryptedPriceKeyValuePair = encryptionService.Encrypt(value.Price);
                string encryptedPrice = encryptedPriceKeyValuePair["data"];
                _priceKey = encryptedPriceKeyValuePair["key"];
                Dictionary<string, string> encryptedImageKeyValuePair = encryptionService.Encrypt(value.Image);
                string encryptedImage = encryptedImageKeyValuePair["data"];
                _imageKey = encryptedImageKeyValuePair["key"];
                _product = new ProductMock
                {
                    Name = encryptedName,
                    Description = encryptedDescription,
                    Price = encryptedPrice,
                    Image = encryptedImage
                };
            }
        }

        public ProductRepository(ProductMock product)
        {
            Product = product;
        }
    }
}
