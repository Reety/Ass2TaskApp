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

namespace YourTimeApp
{
    /// <summary>
    /// Interaction logic for SessionStarted.xaml
    /// </summary>
    public partial class SessionStarted : Window
    {
        private SessionTimer timer;
        private DispatcherTimer uiTimer;
        public SessionStarted()
        {
            InitializeComponent();

            timer = new SessionTimer(new TimeSpan(0, 1, 0));
            uiTimer = new DispatcherTimer();
            uiTimer.Interval = TimeSpan.FromSeconds(1);
            uiTimer.Tick += new EventHandler(OnTimerSecond);
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            uiTimer.Start();
        }

        private void OnTimerSecond(object sender, EventArgs e)
        {
            MainLabel.Content = $"{timer.TimeLeft}";
            if (!timer.TimerEnabled) uiTimer.Stop();
        }

    }
}
