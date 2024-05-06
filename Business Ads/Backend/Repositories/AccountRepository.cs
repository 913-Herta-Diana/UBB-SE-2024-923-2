// <copyright file="AccountRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using Backend.Models;
    using Backend.Services;

    public class AccountRepository
    {
        private readonly DataEncryptionService encryptionService = new ();
        private BankAccount bankAccount;
        private string emailKey;
        private string nameKey;
        private string surnameKey;
        private string phoneNumberKey;
        private string countyKey;
        private string cityKey;
        private string addressKey;
        private string numberKey;
        private string holderNameKey;
        private string expirationDateKey;

        public AccountRepository(BankAccount account)
        {
            this.BankAccount = account;
        }

        public BankAccount BankAccount
        {
            get
            {
                string decryptedEmail = this.encryptionService.Decrypt(this.bankAccount.Email, this.emailKey);
                string decryptedName = this.encryptionService.Decrypt(this.bankAccount.Name, this.nameKey);
                string decryptedSurname = this.encryptionService.Decrypt(this.bankAccount.Surname, this.surnameKey);
                string decryptedPhoneNumber = this.encryptionService.Decrypt(this.bankAccount.PhoneNumber, this.phoneNumberKey);
                string decryptedCounty = this.encryptionService.Decrypt(this.bankAccount.County, this.countyKey);
                string decryptedCity = this.encryptionService.Decrypt(this.bankAccount.City, this.cityKey);
                string decryptedAddress = this.encryptionService.Decrypt(this.bankAccount.Address, this.addressKey);
                string decryptedNumber = this.encryptionService.Decrypt(this.bankAccount.Number, this.numberKey);
                string decryptedHolderName = this.encryptionService.Decrypt(this.bankAccount.HolderName, this.holderNameKey);
                string decryptedExpiryDate = this.encryptionService.Decrypt(this.bankAccount.ExpiryDate, this.expirationDateKey);
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
                    ExpiryDate = decryptedExpiryDate,
                };
            }

            set
            {
                Dictionary<string, string> encryptedEmailKeyValuePair = this.encryptionService.Encrypt(value.Email);
                string encryptedEmail = encryptedEmailKeyValuePair["data"];
                this.emailKey = encryptedEmailKeyValuePair["key"];
                Dictionary<string, string> encryptedNameKeyValuePair = this.encryptionService.Encrypt(value.Name);
                string encryptedName = encryptedNameKeyValuePair["data"];
                this.nameKey = encryptedNameKeyValuePair["key"];
                Dictionary<string, string> encryptedSurnameKeyValuePair = this.encryptionService.Encrypt(value.Surname);
                string encryptedSurname = encryptedSurnameKeyValuePair["data"];
                this.surnameKey = encryptedSurnameKeyValuePair["key"];
                Dictionary<string, string> encryptedPhoneNumberKeyValuePair = this.encryptionService.Encrypt(value.PhoneNumber);
                string encryptedPhoneNumber = encryptedPhoneNumberKeyValuePair["data"];
                this.phoneNumberKey = encryptedPhoneNumberKeyValuePair["key"];
                Dictionary<string, string> encryptedCountyKeyValuePair = this.encryptionService.Encrypt(value.County);
                string encryptedCounty = encryptedCountyKeyValuePair["data"];
                this.countyKey = encryptedCountyKeyValuePair["key"];
                Dictionary<string, string> encryptedCityKeyValuePair = this.encryptionService.Encrypt(value.City);
                string encryptedCity = encryptedCityKeyValuePair["data"];
                this.cityKey = encryptedCityKeyValuePair["key"];
                Dictionary<string, string> encryptedAddressKeyValuePair = this.encryptionService.Encrypt(value.Address);
                string encryptedAddress = encryptedAddressKeyValuePair["data"];
                this.addressKey = encryptedAddressKeyValuePair["key"];
                Dictionary<string, string> encryptedNumberKeyValuePair = this.encryptionService.Encrypt(value.Number);
                string encryptedNumber = encryptedNumberKeyValuePair["data"];
                this.numberKey = encryptedNumberKeyValuePair["key"];
                Dictionary<string, string> encryptedHolderNameKeyValuePair = this.encryptionService.Encrypt(value.HolderName);
                string encryptedHolderName = encryptedHolderNameKeyValuePair["data"];
                this.holderNameKey = encryptedHolderNameKeyValuePair["key"];
                Dictionary<string, string> encryptedExpiryDateKeyValuePair = this.encryptionService.Encrypt(value.ExpiryDate);
                string encryptedExpiryDate = encryptedExpiryDateKeyValuePair["data"];
                this.expirationDateKey = encryptedExpiryDateKeyValuePair["key"];
                this.bankAccount = new BankAccount
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
                    ExpiryDate = encryptedExpiryDate,
                };
            }
        }
    }
}
