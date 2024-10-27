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
using System.Windows.Navigation;
using System.Windows.Shapes;
using YourTimeApp.ViewModels;

namespace YourTimeApp
{
    /// <summary>
    /// Interaction logic for CurrentSession.xaml
    /// </summary>
    public partial class CurrentSession : UserControl
    {
        public CurrentSession(SessionStartViewModel vm)
        {
            this.DataContext = vm;
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton checkedButton = (RadioButton)sender;

        }

        private void PauseTimer_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.Content = ((string)clickedButton.Content == "Pause") ? "Resume" : "Pause";
        }
    }
}
