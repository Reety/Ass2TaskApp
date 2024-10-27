using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private System.Collections.IList selectedItems;
        public ObservableCollection<object> SelectedItems => (ObservableCollection<object>)selectedItems;
            
        public SessionStart()
        {
            InitializeComponent();
            selectedItems = savedTasks.SelectedItems;
        }

        private void savedTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vm = (SessionStartViewModel)DataContext;
            vm.SelectedItems = new ObservableCollection<UserTaskViewModel>(savedTasks.SelectedItems.Cast<UserTaskViewModel>());
        }
    }
}
