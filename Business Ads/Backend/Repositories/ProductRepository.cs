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
                Dictionary<string, string> encryptedNameKVPair = encryptionService.Encrypt(value.Name);
                string encryptedName = encryptedNameKVPair["data"];
                _nameKey = encryptedNameKVPair["key"];
                Dictionary<string, string> encryptedDescriptionKVPair = encryptionService.Encrypt(value.Description);
                string encryptedDescription = encryptedDescriptionKVPair["data"];
                _descriptionKey = encryptedDescriptionKVPair["key"];
                Dictionary<string, string> encryptedPriceKVPair = encryptionService.Encrypt(value.Price);
                string encryptedPrice = encryptedPriceKVPair["data"];
                _priceKey = encryptedPriceKVPair["key"];
                Dictionary<string, string> encryptedImageKVPair = encryptionService.Encrypt(value.Image);
                string encryptedImage = encryptedImageKVPair["data"];
                _imageKey = encryptedImageKVPair["key"];
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
