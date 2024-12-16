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
using System.Windows.Navigation;
using System.Windows.Shapes;
using YourTimeApp.ViewModels;

namespace YourTimeApp.Views
{
    /// <summary>
    /// Interaction logic for CreateSession.xaml
    /// </summary>
    public partial class CreateSessionView : UserControl
    {
        private System.Collections.IList selectedItems;
        public ObservableCollection<object> SelectedItems => (ObservableCollection<object>)selectedItems;

        public CreateSessionView()
        {
            InitializeComponent();
        }

        private void savedTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vm = (CreateSessionViewModel)DataContext;
            vm.SelectedItems = new ObservableCollection<UserTaskViewModel>(savedTasks.SelectedItems.Cast<UserTaskViewModel>());
        }
    }
}
