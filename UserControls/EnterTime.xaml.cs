using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace YourTimeApp.UserControls
{
    /// <summary>
    /// Interaction logic for EnterTime.xaml
    /// </summary>
    public partial class EnterTime : UserControl, INotifyPropertyChanged
    {
        public EnterTime()
        {
 
            InitializeComponent();
            LoadHours();
            LoadMinutes();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void LoadHours()
        {
            for (int i = 0; i < 24; i++)
            {
                Hrs.Items.Add(i);
            }
        }
        private void LoadMinutes()
        {
            for (int i = 0; i < 60; i++)
            {
                Mins.Items.Add(i);
            }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
