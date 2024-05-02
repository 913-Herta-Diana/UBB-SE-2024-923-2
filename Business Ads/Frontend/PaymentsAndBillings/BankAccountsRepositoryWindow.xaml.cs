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
        public Window MainWindow;
        private readonly BankAccountController bankAccountController;

        public BankAccountsRepositoryWindow(BankAccountController bankAccountControllerInstance)
        {
            bankAccountController = bankAccountControllerInstance;
            InitializeComponent();
            UpdateFields();

            Closed += (sender, EventData) =>
            {
                MainWindow.Show();
            };
        }

        private void UpdateFields()
        {
            txtEmail.Text = bankAccountController.GetBankAccount().Email;
            txtName.Text = bankAccountController.GetBankAccount().Name;
            txtSurname.Text = bankAccountController.GetBankAccount().Surname;
            txtPhoneNumber.Text = bankAccountController.GetBankAccount().PhoneNumber;
            txtCounty.Text = bankAccountController.GetBankAccount().County;
            txtCity.Text = bankAccountController.GetBankAccount().City;
            txtAddress.Text = bankAccountController.GetBankAccount().Address;
            txtNumber.Text = bankAccountController.GetBankAccount().Number;
            txtHolderName.Text = bankAccountController.GetBankAccount().HolderName;
            txtExpiryDate.Text = bankAccountController.GetBankAccount().ExpiryDate;
        }

        private void HomePage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Profile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Profile clicked!");
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bankAccountController.UpdateBankAccount(txtName.Text, txtSurname.Text, 
                    txtEmail.Text, txtPhoneNumber.Text, txtCounty.Text, txtCity.Text, 
                    txtAddress.Text, txtNumber.Text, txtHolderName.Text, txtExpiryDate.Text);
                MessageBox.Show("Bank account updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateFields();
            }
        }

        private void HomePage_MouseEnter(object sender, MouseEventArgs e)
        {
            homePageBlock.Background = Brushes.LightGray;
        }

        private void HomePage_MouseLeave(object sender, MouseEventArgs e)
        {
            homePageBlock.Background = Brushes.DimGray;
        }

        private void Profile_MouseEnter(object sender, MouseEventArgs e)
        {
            profileBlock.Background = Brushes.LightGray;
        }

        private void Profile_MouseLeave(object sender, MouseEventArgs e)
        {
            profileBlock.Background = Brushes.DimGray;
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Profile clicked!");
        }
    }
}
