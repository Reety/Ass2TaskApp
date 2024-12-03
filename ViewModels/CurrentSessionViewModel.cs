using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YourTimeApp.Data;

namespace YourTimeApp.ViewModels
{
    public class CurrentSessionViewModel : ViewModelBase
    {
        YourTimeStore appStore;

        private SoundPlayer alarm = new SoundPlayer("Alarm.wav");
        private EndSessionViewModel endSessionView;

        private TimeBlockViewModel? currentTimeBlock;
        public TimeBlockViewModel? CurrentTimeBlock
        {
            get => currentTimeBlock;
            set
            {
                currentTimeBlock = value;
                OnPropertyChanged();
            }
        }
        public CurrentSessionViewModel(YourTimeStore appStore)
        {
            this.appStore = appStore;
            appStore.TimeBlockStarted += OnTimeBlockStarted;
            endSessionView = new EndSessionViewModel(appStore);
        }

        public RelayCommand StartTimerCommand => new RelayCommand(execute => StartTimer(), canExecute => ((CurrentTimeBlock != null) && CurrentTimeBlock.CurrentTask != null && !CurrentTimeBlock.Timer.TimerStarted));
        public RelayCommand PauseTimerCommand => new RelayCommand(execute => PauseTimer(), canExecute => ((CurrentTimeBlock != null) && !CurrentTimeBlock.Timer.TimerEnded));

        public RelayCommand StopTimerCommand => new RelayCommand(execute => StopTimer(), canExecute => ((CurrentTimeBlock != null)));

        public RelayCommand ChangeCurrentTaskCommand => new RelayCommand(execute => ChangeCurrentTask((TaskTimeViewModel)execute), canExecute => ((CurrentTimeBlock != null) && CurrentTimeBlock.CurrentTask != canExecute));

        private void ChangeCurrentTask(TaskTimeViewModel currentTask)
        {
            CurrentTimeBlock.CurrentTask = currentTask;
        }

        private void StartTimer()
        {
            CurrentTimeBlock.Timer.Start();
        }

        private void PauseTimer()
        {

            if (CurrentTimeBlock.Timer.Paused) CurrentTimeBlock.Timer.Resume();
            else CurrentTimeBlock.Timer.Pause();
        }

        private void StopTimer()
        {
            CurrentTimeBlock.EndBlock();

            appStore.EndTimeBlock(currentTimeBlock);

            EndSession endView = new EndSession();
            Window endSession = new Window()
            {
                Title = "Session Summary",
                Content = new EndSession()
                {
                    DataContext = endSessionView
                },
                SizeToContent = SizeToContent.WidthAndHeight,
                Width = endView.Width + 100,
                Height = endView.Height + 100,
                ResizeMode = ResizeMode.CanResize
            };
            endSession.ShowDialog();


        }

        private void OnTimeBlockStarted(TimeBlockViewModel timeBlock)
        {
            CurrentTimeBlock = timeBlock;
            CurrentTimeBlock.TimerEnded += RingAlarm;
        }

        public void RingAlarm()
        {
            alarm.PlayLooping();
            MessageBox.Show("Time is over!", "Time Over", MessageBoxButton.OK);
            alarm.Stop();
            alarm.Dispose();
            StopTimer();
        }

    }
}
