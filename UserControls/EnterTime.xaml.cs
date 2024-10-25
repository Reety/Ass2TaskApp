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
        private string hours;

        public string Hours
        {
            get { return hours; }
            set { hours = value;
                OnPropertyChanged();
            }
        }

        public float HoursFloat
        {
            get { return float.Parse(hours); }
            set { if (float.TryParse(value.ToString(), out float result)) HoursFloat = result;
                else throw new Exception();
                OnPropertyChanged();
            }
        }

        public EnterTime()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
