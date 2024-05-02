using System.Windows;
using System.Windows.Controls;
using Backend.Services;

namespace Frontend.FAQ
{
    /// <summary>
    /// Interaction logic for SubmitQuestion.xaml
    /// </summary>
    public partial class SubmitQuestion : Window
    {
        private readonly FAQService service;
        private readonly List<string> topics;
        //private readonly List<Backend.Models.FAQ> faqs;
        public SubmitQuestion()
        {
            InitializeComponent();

            service = FAQService.Instance;

            topics = service.GetTopics();

            dropTopic.ItemsSource = topics;
        }

        private void QuestionBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Input question here...")
            {
                textBox.Text = "";
            }
        }


        private void QuestionBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Input question here...";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string question = questionBox.Text;
            string selectedTopic = dropTopic.SelectedItem as string;
            Backend.Models.FAQ newQ = new(question, "to be added", selectedTopic);
            service.AddSubmittedQuestion(newQ);
            MessageBox.Show("The question has been submitted. Check the FAQ page later to see if it has been approved.");
        }
    }
}
