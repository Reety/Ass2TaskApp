using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using YourTimeApp.Data;
using YourTimeApp.ViewModels;
using YourTimeApp.UserControls;

namespace YourTimeApp
{
    /// <summary>
    /// Interaction logic for CreateTasks.xaml
    /// </summary>
    public partial class CreateTask : Window
    {

        public CreateTask()
        {
            this.DataContext = new CreateTaskViewModel();
            InitializeComponent();
        }
        private void textBox1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                
            }
        }

        private void CreateSesh_Click(object sender, RoutedEventArgs e)
        {
            new SessionStart().Show();
        }
    }
}
