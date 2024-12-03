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

namespace YourTimeApp
{
    /// <summary>
    /// Interaction logic for CreateTasks.xaml
    /// </summary>
    public partial class CreateTask : Window
    {

        public CreateTask()
        {
            InitializeComponent();
        }

        private void CreateSesh_Click(object sender, RoutedEventArgs e)
        {
            new SessionStart().Show();
        }
    }
}
