using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YourTimeApp.Data;
using YourTimeApp.DB;


namespace YourTimeApp.ViewModels
{
    public class SessionStartViewModel : ViewModelBase
    {

        private TimeBlockViewModel? currentTimeBlock;
        public TimeBlockViewModel? CurrentTimeBlock { 
            get => currentTimeBlock;
            set
            {
                currentTimeBlock = value;
                OnPropertyChanged();
            }
        }

        private SessionStart seshStartView;


        public ObservableCollection<UserTaskViewModel> AllTasks { get; set; } = [];
        //public ObservableCollection<UserTaskViewModel> SelectedItems = [];
        public SessionStartViewModel(SessionStart seshView)
        {
            this.seshStartView = seshView;
            AllTasks = CreateTaskViewModel.Tasks;
                  
        }



		public RelayCommand StartTimeCommand => new RelayCommand(execute => { }, canExecute => { return true; });
        public RelayCommand StartSeshCommand => new RelayCommand(execute => StartSession(), canExecute => (seshStartView.SelectedItems != null && CurrentTimeBlock == null));

        public RelayCommand StartTimerCommand => new RelayCommand(execute => StartTimer(), canExecute => ((CurrentTimeBlock != null) && CurrentTimeBlock.CurrentTask != null && !CurrentTimeBlock.Timer.TimerStarted));
        public RelayCommand PauseTimerCommand => new RelayCommand(execute => PauseTimer(), canExecute => ((CurrentTimeBlock != null) && !CurrentTimeBlock.Timer.TimerEnded));

        public RelayCommand StopTimerCommand => new RelayCommand(execute => StopTimer(), canExecute => ((CurrentTimeBlock != null)));

        public RelayCommand ChangeCurrentTaskCommand => new RelayCommand(execute => ChangeCurrentTask((TaskTimeViewModel)execute),canExecute => ((CurrentTimeBlock != null) && CurrentTimeBlock.CurrentTask != canExecute));
        private void StartSession()
        {
            TimeBlock tbModel = new TimeBlock();
            CurrentTimeBlock = new TimeBlockViewModel(tbModel);

            foreach (UserTaskViewModel task in seshStartView.SelectedItems) {
                CurrentTimeBlock.AddTask(task);
            }

            CurrentSession session = new CurrentSession(this);
            Window window = new Window
            {
                Title = "Current Session",
                Content = session,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();
        }

        private void ChangeCurrentTask(TaskTimeViewModel currentTask)
        {
            CurrentTimeBlock.CurrentTask = currentTask;
        }

        private void StartTimer()
		{
            CurrentTimeBlock.Timer.Start();
		}

        private void PauseTimer() { 

            if (CurrentTimeBlock.Timer.Paused) CurrentTimeBlock.Timer.Resume();
            else CurrentTimeBlock.Timer.Pause();
        }

        private void StopTimer() { CurrentTimeBlock.Timer.Stop(); }
	}
}
