// <copyright file="AccountRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using Backend.Models;
    using Backend.Services;

    public class AccountRepository : IAccountRepository
    {
        private readonly DataEncryptionService encryptionService = new ();
        private BankAccount bankAccount = new BankAccount();
        private string? emailKey;
        private string? nameKey;
        private string? surnameKey;
        private string? phoneNumberKey;
        private string? countyKey;
        private string? cityKey;
        private string? addressKey;
        private string? numberKey;
        private string? holderNameKey;
        private string? expirationDateKey;

        public AccountRepository(BankAccount account)
        {
            BankAccount = account ?? throw new ArgumentNullException(nameof(account));
        }

        public AccountRepository(BankAccount account, DataEncryptionService encryptionService)
        {
            this.encryptionService = encryptionService ?? throw new ArgumentNullException(nameof(encryptionService));
            BankAccount = account ?? throw new ArgumentNullException(nameof(account));
        }

        public BankAccount BankAccount
        {
            get
            {
                string? decryptedEmail = encryptionService.Decrypt(bankAccount.Email!, emailKey!);
                string? decryptedName = encryptionService.Decrypt(bankAccount.Name!, nameKey!);
                string? decryptedSurname = encryptionService.Decrypt(bankAccount.Surname!, surnameKey!);
                string? decryptedPhoneNumber = encryptionService.Decrypt(bankAccount.PhoneNumber!, phoneNumberKey!);
                string? decryptedCounty = encryptionService.Decrypt(bankAccount.County!, countyKey!);
                string? decryptedCity = encryptionService.Decrypt(bankAccount.City!, cityKey!);
                string? decryptedAddress = encryptionService.Decrypt(bankAccount.Address!, addressKey!);
                string? decryptedNumber = encryptionService.Decrypt(bankAccount.Number!, numberKey!);
                string? decryptedHolderName = encryptionService.Decrypt(bankAccount.HolderName!, holderNameKey!);
                string? decryptedExpiryDate = encryptionService.Decrypt(bankAccount.ExpiryDate!, expirationDateKey!);

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
                Dictionary<string, string> encryptedEmailKeyValuePair = encryptionService.Encrypt(value.Email!);
                string encryptedEmail = encryptedEmailKeyValuePair["data"];
                emailKey = encryptedEmailKeyValuePair["key"];
                Dictionary<string, string> encryptedNameKeyValuePair = encryptionService.Encrypt(value.Name!);
                string encryptedName = encryptedNameKeyValuePair["data"];
                nameKey = encryptedNameKeyValuePair["key"];
                Dictionary<string, string> encryptedSurnameKeyValuePair = encryptionService.Encrypt(value.Surname!);
                string encryptedSurname = encryptedSurnameKeyValuePair["data"];
                surnameKey = encryptedSurnameKeyValuePair["key"];
                Dictionary<string, string> encryptedPhoneNumberKeyValuePair = encryptionService.Encrypt(value.PhoneNumber!);
                string encryptedPhoneNumber = encryptedPhoneNumberKeyValuePair["data"];
                phoneNumberKey = encryptedPhoneNumberKeyValuePair["key"];
                Dictionary<string, string> encryptedCountyKeyValuePair = encryptionService.Encrypt(value.County!);
                string encryptedCounty = encryptedCountyKeyValuePair["data"];
                countyKey = encryptedCountyKeyValuePair["key"];
                Dictionary<string, string> encryptedCityKeyValuePair = encryptionService.Encrypt(value.City!);
                string encryptedCity = encryptedCityKeyValuePair["data"];
                cityKey = encryptedCityKeyValuePair["key"];
                Dictionary<string, string> encryptedAddressKeyValuePair = encryptionService.Encrypt(value.Address!);
                string encryptedAddress = encryptedAddressKeyValuePair["data"];
                addressKey = encryptedAddressKeyValuePair["key"];
                Dictionary<string, string> encryptedNumberKeyValuePair = encryptionService.Encrypt(value.Number!);
                string encryptedNumber = encryptedNumberKeyValuePair["data"];
                numberKey = encryptedNumberKeyValuePair["key"];
                Dictionary<string, string> encryptedHolderNameKeyValuePair = encryptionService.Encrypt(value.HolderName!);
                string encryptedHolderName = encryptedHolderNameKeyValuePair["data"];
                holderNameKey = encryptedHolderNameKeyValuePair["key"];
                Dictionary<string, string> encryptedExpiryDateKeyValuePair = encryptionService.Encrypt(value.ExpiryDate!);
                string encryptedExpiryDate = encryptedExpiryDateKeyValuePair["data"];
                expirationDateKey = encryptedExpiryDateKeyValuePair["key"];
                bankAccount = new BankAccount
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
