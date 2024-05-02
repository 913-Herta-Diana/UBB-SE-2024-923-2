using Backend.Models;
using Backend.Repositories;
using System.Net;
using System.Net.Mail;

namespace Backend.Controllers
{
    public class PaymentFormController(AccountRepository repositoryAccount, ProductRepository repositoryProduct)
    {
        private readonly AccountRepository _accountRepository = repositoryAccount;
        private readonly ProductRepository _productRepository = repositoryProduct;

        public Task SendPaymentConfirmationMailAsync()
        {
            var sender = "osvathrobert03@gmail.com";
            var receiver = _accountRepository.BankAccount.Email;
            var password = "daes ndml ukpj qvuj";

            var product = _productRepository.Product;
            var subject = "Running tests im sorry";
           // var subject = "Payment Confirmation For " + product.Name;
            var message = "Description: " + product.Description + "\nPrice: " + product.Price;

            var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(sender, password),
                EnableSsl = true
            };

            var mail = new MailMessage(
                from: sender,
                to: receiver,
                subject: subject,
                body: message
            );
            return client.SendMailAsync(mail);
        }

        public ProductMock GetProduct()
        {
            return _productRepository.Product;
        }
    }
}
