// <copyright file="BankAccountsRepositoryWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frontend.PaymentsAndBillings
{
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using Backend.Controllers;

    /// <summary>
    /// Interaction logic for BankAccountsRepositoryWindow.xaml.
    /// </summary>
    public partial class BankAccountsRepositoryWindow : Window
    {
#pragma warning disable SA1401 // Fields should be private
        public Window? MainWindow;
#pragma warning restore SA1401 // Fields should be private
        private readonly BankAccountController bankAccountController;

        public BankAccountsRepositoryWindow(BankAccountController bankAccountControllerInstance)
        {
            this.bankAccountController = bankAccountControllerInstance;
            this.InitializeComponent();
            this.UpdateFields();

            this.Closed += (sender, eventData) =>
            {
                this.MainWindow!.Show();
            };
        }

        private void UpdateFields()
        {
            this.txtEmail.Text = this.bankAccountController.GetBankAccount().Email;
            this.txtName.Text = this.bankAccountController.GetBankAccount().Name;
            this.txtSurname.Text = this.bankAccountController.GetBankAccount().Surname;
            this.txtPhoneNumber.Text = this.bankAccountController.GetBankAccount().PhoneNumber;
            this.txtCounty.Text = this.bankAccountController.GetBankAccount().County;
            this.txtCity.Text = this.bankAccountController.GetBankAccount().City;
            this.txtAddress.Text = this.bankAccountController.GetBankAccount().Address;
            this.txtNumber.Text = this.bankAccountController.GetBankAccount().Number;
            this.txtHolderName.Text = this.bankAccountController.GetBankAccount().HolderName;
            this.txtExpiryDate.Text = this.bankAccountController.GetBankAccount().ExpiryDate;
        }

        private void HomePage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Profile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Profile clicked!");
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.bankAccountController.UpdateBankAccount(this.txtName.Text, this.txtSurname.Text, this.txtEmail.Text, this.txtPhoneNumber.Text, this.txtCounty.Text, this.txtCity.Text, this.txtAddress.Text, this.txtNumber.Text, this.txtHolderName.Text, this.txtExpiryDate.Text);
                MessageBox.Show("Bank account updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.UpdateFields();
            }
        }

        private void HomePage_MouseEnter(object sender, MouseEventArgs e)
        {
            this.homePageBlock.Background = Brushes.LightGray;
        }

        private void HomePage_MouseLeave(object sender, MouseEventArgs e)
        {
            this.homePageBlock.Background = Brushes.DimGray;
        }

        private void Profile_MouseEnter(object sender, MouseEventArgs e)
        {
            this.profileBlock.Background = Brushes.LightGray;
        }

        private void Profile_MouseLeave(object sender, MouseEventArgs e)
        {
            this.profileBlock.Background = Brushes.DimGray;
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Profile clicked!");
        }
    }
}
