using System.Text;
using System.Windows;
using System.Windows.Controls;
using Backend.Services;
using Backend.Models;

namespace Frontend.FAQ
{
    /// <summary>
    /// Interaction logic for AdminMode.xaml
    /// </summary>
    public partial class AdminMode : Window
    {
        private readonly TODOServices todoServices;
        private readonly ReviewService reviewService;

        public AdminMode()
        {
            todoServices = TODOServices.Instance;
            reviewService = ReviewService.Instance;
            InitializeComponent();
            PopulateTodoList();
            PopulateReviewList();
        }

        private void PopulateReviewList()
        {
            List<ReviewClass> reviews = reviewService.GetAllReviews();
            if (reviews != null)
            {
                StringBuilder stringBuilderInstance = new();
                foreach (ReviewClass review in reviews)
                {
                    stringBuilderInstance.AppendLine(review.ToString());
                }

                reviewBlock.Text = stringBuilderInstance.ToString();
            }
            else
            {
                reviewBlock.Text = "";
            }
        }

        private void PopulateTodoList()
        {
            List<TODOClass> todos = todoServices.GetTODOS();
            if (todos != null)
            {
                StringBuilder stringBuilderInstance = new();
                foreach (TODOClass todo in todos)
                {
                    stringBuilderInstance.AppendLine(todo.ToString());
                }

                todoTextBlock.Text = stringBuilderInstance.ToString();
            }
            else
            {
                todoTextBlock.Text = "";
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == "Input number of finished task")
            {
                textBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Input number of finished task";
            }
        }

        private void addTask_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == "Input new task here")
            {
                textBox.Text = "";
            }
        }

        private void addTask_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Input new task here";
            }
        }

        private void removeTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(removeText.Text, out int idToRemove))
            {
                todoServices.RemoveTODO(idToRemove);
                PopulateTodoList();
                removeText.Text = "Input number of finished task"; 
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.");
            }

        }

        private void addTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string newTask = addTask.Text;
            if (!string.IsNullOrWhiteSpace(newTask))
            {
                TODOClass task = new(newTask);
                todoServices.AddTODO(task);
            }

            PopulateTodoList();
        }
}
}
