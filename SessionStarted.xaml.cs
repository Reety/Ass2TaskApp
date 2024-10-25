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
    /// Interaction logic for SessionStarted.xaml
    /// </summary>
    public partial class SessionStarted : Window
    {
        private SessionStartedViewModel vm = new SessionStartedViewModel();
        private TimeBlock sesh;
        private DispatcherTimer uiTimer = new DispatcherTimer();
        private DispatcherTimer taskTimer = new DispatcherTimer();
        public SessionStarted()
        {
            InitializeComponent();

            sesh = new TimeBlock();
            uiTimer.Interval = TimeSpan.FromSeconds(1);
            taskTimer.Interval = TimeSpan.FromSeconds(1);
            uiTimer.Tick += new EventHandler(OnTimerSecond);
            taskTimer.Tick += new EventHandler(OnTaskSecond);
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            sesh.Timer.Start();
            uiTimer.Start();
        }

        private void StartTaskButton_Click(object sender, RoutedEventArgs eventArgs)
        {
            sesh.AddToDo("Test our code");
            sesh.CurrentTaskFinished += TaskEnded;
            taskTimer.Start();

        }
        private void OnTimerSecond(object sender, EventArgs e)
        {
            MainLabel.Content = $"{sesh.Timer.TimeRemaining}";
            if (!sesh.Timer.TimerEnabled) uiTimer.Stop();
        }

        private void OnTaskSecond(object sender, EventArgs e)
        {
            TaskTimer.Content = $"{CurrentTask.TimeLeft}";
        }

        private void TaskEnded()
        {
            TaskTimer.Content = $"TASK FINISHED";
            taskTimer.Stop();
        }



    }
}
