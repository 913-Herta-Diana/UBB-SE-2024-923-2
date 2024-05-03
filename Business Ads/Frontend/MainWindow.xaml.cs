// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frontend
{
    using System.Windows;
    using Frontend.PaymentsAndBillings;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.Loaded += (sender, eventData) =>
            {
                this.StatsButton.Click += (sender, eventData) =>
                {
                    StatsWindow statsWindow = new ()
                    {
                        MainWindow = this,
                    };
                    statsWindow.Show();
                    this.Hide();
                };
                this.ExportButton.Click += (sender, eventData) =>
                {
                    ExportWindow exportWindow = new ()
                    {
                        MainWindow = this,
                    };
                    exportWindow.Show();
                    this.Hide();
                };
                this.BillingButton.Click += (sender, eventData) =>
                {
                    PaymentsAndBillingsMain billingWindow = new ()
                    {
                        mainWindow = this,
                    };
                    billingWindow.Show();
                    this.Hide();
                };
                this.faqButton.Click += (sender, eventData) =>
                {
                    FAQWindow faqWindow = new ()
                    {
                        MainWindow = this,
                    };
                    faqWindow.Show();
                    this.Hide();
                };

                this.Closed += (sender, eventData) =>
                {
                    Application.Current.Shutdown();
                };
            };
        }
    }
}
