using Backend.Models;
using Backend.Services;

namespace Backend.Repositories
{
    public class AccountRepository
    {
        private DataEncryptionService encryptionService = new DataEncryptionService();
        private BankAccount _bankAccount;
        private string _emailKey;
        private string _nameKey;
        private string _surnameKey;
        private string _phoneNumberKey;
        private string _countyKey;
        private string _cityKey;
        private string _addressKey;
        private string _numberKey;
        private string _holderNameKey;
        private string _expiryDateKey;
        
        public BankAccount BankAccount
        {
            get
            {
                string decryptedEmail = encryptionService.Decrypt(_bankAccount.Email, _emailKey);
                string decryptedName = encryptionService.Decrypt(_bankAccount.Name, _nameKey);
                string decryptedSurname = encryptionService.Decrypt(_bankAccount.Surname, _surnameKey);
                string decryptedPhoneNumber = encryptionService.Decrypt(_bankAccount.PhoneNumber, _phoneNumberKey);
                string decryptedCounty = encryptionService.Decrypt(_bankAccount.County, _countyKey);
                string decryptedCity = encryptionService.Decrypt(_bankAccount.City, _cityKey);
                string decryptedAddress = encryptionService.Decrypt(_bankAccount.Address, _addressKey);
                string decryptedNumber = encryptionService.Decrypt(_bankAccount.Number, _numberKey);
                string decryptedHolderName = encryptionService.Decrypt(_bankAccount.HolderName, _holderNameKey);
                string decryptedExpiryDate = encryptionService.Decrypt(_bankAccount.ExpiryDate, _expiryDateKey);
                return new BankAccount
                {
                    Email = decryptedEmail,
                    Name = decryptedName,
                    Surname = decryptedSurname,
                    PhoneNumber = decryptedPhoneNumber,
                    County = decryptedCounty,
                    City = decryptedCity,
                    Address = decryptedAddress,
                    Number = decryptedNumber,
                    HolderName = decryptedHolderName,
                    ExpiryDate = decryptedExpiryDate
                };
            }
            set
            {
                Dictionary<string, string> encryptedEmailKVPair = encryptionService.Encrypt(value.Email);
                string encryptedEmail = encryptedEmailKVPair["data"];
                _emailKey = encryptedEmailKVPair["key"];
                Dictionary<string, string> encryptedNameKVPair = encryptionService.Encrypt(value.Name);
                string encryptedName = encryptedNameKVPair["data"];
                _nameKey = encryptedNameKVPair["key"];
                Dictionary<string, string> encryptedSurnameKVPair = encryptionService.Encrypt(value.Surname);
                string encryptedSurname = encryptedSurnameKVPair["data"];
                _surnameKey = encryptedSurnameKVPair["key"];
                Dictionary<string, string> encryptedPhoneNumberKVPair = encryptionService.Encrypt(value.PhoneNumber);
                string encryptedPhoneNumber = encryptedPhoneNumberKVPair["data"];
                _phoneNumberKey = encryptedPhoneNumberKVPair["key"];
                Dictionary<string, string> encryptedCountyKVPair = encryptionService.Encrypt(value.County);
                string encryptedCounty = encryptedCountyKVPair["data"];
                _countyKey = encryptedCountyKVPair["key"];
                Dictionary<string, string> encryptedCityKVPair = encryptionService.Encrypt(value.City);
                string encryptedCity = encryptedCityKVPair["data"];
                _cityKey = encryptedCityKVPair["key"];
                Dictionary<string, string> encryptedAddressKVPair = encryptionService.Encrypt(value.Address);
                string encryptedAddress = encryptedAddressKVPair["data"];
                _addressKey = encryptedAddressKVPair["key"];
                Dictionary<string, string> encryptedNumberKVPair = encryptionService.Encrypt(value.Number);
                string encryptedNumber = encryptedNumberKVPair["data"];
                _numberKey = encryptedNumberKVPair["key"];
                Dictionary<string, string> encryptedHolderNameKVPair = encryptionService.Encrypt(value.HolderName);
                string encryptedHolderName = encryptedHolderNameKVPair["data"];
                _holderNameKey = encryptedHolderNameKVPair["key"];
                Dictionary<string, string> encryptedExpiryDateKVPair = encryptionService.Encrypt(value.ExpiryDate);
                string encryptedExpiryDate = encryptedExpiryDateKVPair["data"];
                _expiryDateKey = encryptedExpiryDateKVPair["key"];
                _bankAccount =  new BankAccount
                {
                    Email = encryptedEmail,
                    Name = encryptedName,
                    Surname = encryptedSurname,
                    PhoneNumber = encryptedPhoneNumber,
                    County = encryptedCounty,
                    City = encryptedCity,
                    Address = encryptedAddress,
                    Number = encryptedNumber,
                    HolderName = encryptedHolderName,
                    ExpiryDate = encryptedExpiryDate
                };
            }
        }

        public AccountRepository(BankAccount account)
        {
            BankAccount = account;
        }
    }
}
