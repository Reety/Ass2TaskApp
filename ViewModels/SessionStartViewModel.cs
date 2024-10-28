using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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

        private YourTimeStore appStore;
        private EndSessionViewModel endSessionView;

        public ObservableCollection<UserTaskViewModel> AllTasks { get; set; } = [];
        public ObservableCollection<UserTaskViewModel> SelectedItems { get; set; } = [];
        
        public SessionStartViewModel(YourTimeStore appStore)
        {
            this.appStore = appStore;
            TaskSessionList.Tasks.ForEach(x =>
            {
                if (!AllTasks.Select(t => t.Task).Contains(x)) AllTasks.Add(new UserTaskViewModel(x));
            });
            appStore.TaskCreated += OnTaskCreated;
            endSessionView = new EndSessionViewModel(appStore);
                  
        }



		public RelayCommand StartTimeCommand => new RelayCommand(execute => { }, canExecute => { return true; });
        public RelayCommand StartSeshCommand => new RelayCommand(execute => StartSession(), canExecute => (SelectedItems.Count != 0 && CurrentTimeBlock == null));

        public RelayCommand StartTimerCommand => new RelayCommand(execute => StartTimer(), canExecute => ((CurrentTimeBlock != null) && CurrentTimeBlock.CurrentTask != null && !CurrentTimeBlock.Timer.TimerStarted));
        public RelayCommand PauseTimerCommand => new RelayCommand(execute => PauseTimer(), canExecute => ((CurrentTimeBlock != null) && !CurrentTimeBlock.Timer.TimerEnded));

        public RelayCommand StopTimerCommand => new RelayCommand(execute => StopTimer(), canExecute => ((CurrentTimeBlock != null)));

        public RelayCommand ChangeCurrentTaskCommand => new RelayCommand(execute => ChangeCurrentTask((TaskTimeViewModel)execute),canExecute => ((CurrentTimeBlock != null) && CurrentTimeBlock.CurrentTask != canExecute));
        private void StartSession()
        {
            TimeBlock tbModel = new TimeBlock();
            appStore.CreateTimeBlock(tbModel);

            CurrentTimeBlock = new TimeBlockViewModel(tbModel);

            foreach (UserTaskViewModel task in SelectedItems) {
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

        private void StopTimer() { 

            CurrentTimeBlock.Timer.Stop();

            appStore.EndTimeBlock(currentTimeBlock);

            Window window = new Window
            {
                Title = "Current Session",
                Content = new EndSession()
                {
                    DataContext = endSessionView
                },
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();


        }

        private void OnTaskCreated(UserTask task)
        {
            AllTasks.Add(new UserTaskViewModel(task));
        }

        public override void Dispose()
        {
            appStore.TaskCreated -= OnTaskCreated;
            base.Dispose();
        }
    }
}
