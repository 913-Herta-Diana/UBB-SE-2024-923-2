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
                Dictionary<string, string> encryptedEmailKVPair = this.encryptionService.Encrypt(value.Email);
                string encryptedEmail = encryptedEmailKVPair["data"];
                this.emailKey = encryptedEmailKVPair["key"];
                Dictionary<string, string> encryptedNameKVPair = this.encryptionService.Encrypt(value.Name);
                string encryptedName = encryptedNameKVPair["data"];
                this.nameKey = encryptedNameKVPair["key"];
                Dictionary<string, string> encryptedSurnameKVPair = this.encryptionService.Encrypt(value.Surname);
                string encryptedSurname = encryptedSurnameKVPair["data"];
                this.surnameKey = encryptedSurnameKVPair["key"];
                Dictionary<string, string> encryptedPhoneNumberKVPair = this.encryptionService.Encrypt(value.PhoneNumber);
                string encryptedPhoneNumber = encryptedPhoneNumberKVPair["data"];
                this.phoneNumberKey = encryptedPhoneNumberKVPair["key"];
                Dictionary<string, string> encryptedCountyKVPair = this.encryptionService.Encrypt(value.County);
                string encryptedCounty = encryptedCountyKVPair["data"];
                this.countyKey = encryptedCountyKVPair["key"];
                Dictionary<string, string> encryptedCityKVPair = this.encryptionService.Encrypt(value.City);
                string encryptedCity = encryptedCityKVPair["data"];
                this.cityKey = encryptedCityKVPair["key"];
                Dictionary<string, string> encryptedAddressKVPair = this.encryptionService.Encrypt(value.Address);
                string encryptedAddress = encryptedAddressKVPair["data"];
                this.addressKey = encryptedAddressKVPair["key"];
                Dictionary<string, string> encryptedNumberKVPair = this.encryptionService.Encrypt(value.Number);
                string encryptedNumber = encryptedNumberKVPair["data"];
                this.numberKey = encryptedNumberKVPair["key"];
                Dictionary<string, string> encryptedHolderNameKVPair = this.encryptionService.Encrypt(value.HolderName);
                string encryptedHolderName = encryptedHolderNameKVPair["data"];
                this.holderNameKey = encryptedHolderNameKVPair["key"];
                Dictionary<string, string> encryptedExpiryDateKVPair = this.encryptionService.Encrypt(value.ExpiryDate);
                string encryptedExpiryDate = encryptedExpiryDateKVPair["data"];
                this.expirationDateKey = encryptedExpiryDateKVPair["key"];
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
