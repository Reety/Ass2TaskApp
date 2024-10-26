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
using System.Windows.Threading;
using YourTimeApp.Data;
using YourTimeApp.ViewModels;

namespace YourTimeApp
{
    /// <summary>
    /// Interaction logic for SessionStar.xaml
    /// </summary>
    public partial class SessionStart : Window
    {
        private SessionStartViewModel vm = new SessionStartViewModel();
        public SessionStart()
        {
            this.DataContext = vm;
            InitializeComponent();

        }

    }
}
