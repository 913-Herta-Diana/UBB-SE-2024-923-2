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
        private TODOServices todoServices;
        private ReviewService reviewService;

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
            List<ReviewClass> reviews = reviewService.getAllReviews();
            if (reviews != null)
            {
                StringBuilder stringBuilderInstance = new StringBuilder();
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
            List<TODOClass> todos = todoServices.getTODOS();
            if (todos != null)
            {
                StringBuilder stringBuilderInstance = new StringBuilder();
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
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Input number of finished task")
            {
                textBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Input number of finished task";
            }
        }

        private void addTask_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Input new task here")
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
                todoServices.removeTODO(idToRemove);
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
                TODOClass task = new TODOClass(newTask);
                todoServices.addTODO(task);
            }

            PopulateTodoList();
        }
}
}
