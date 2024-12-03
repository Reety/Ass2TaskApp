using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YourTimeApp.Data;
using YourTimeApp.DB;


namespace YourTimeApp.ViewModels
{
    public class SessionStartViewModel : ViewModelBase
    {

        #region Timer Properties
        private int hours;
        public int Hours
        {
            get => hours;
            set
            {
                hours = value;
                OnPropertyChanged();
            }
        }

        private int minutes;
        public int Minutes
        {
            get => minutes;
            set
            {
                minutes = value;
                OnPropertyChanged();
            }
        }

        #endregion

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
            appStore.TaskDeleted += OnTaskDeleted;
                  
        }



        public RelayCommand StartSeshCommand => new RelayCommand(execute => StartSession(), canExecute => (SelectedItems.Count != 0 && !(Hours == 0 && Minutes == 0)));
        public RelayCommand GoBackTasks => new RelayCommand(execute => BackToTasks((Window)execute));

        private void BackToTasks(Window currentWindow)
        {
            CreateTask taskView = new CreateTask()
            {
                DataContext = new CreateTaskViewModel(appStore),
            };
            taskView.Show();

            Dispose();
            currentWindow.Close();
      
            
        }

        private void StartSession()
        {
            TimeBlock tbModel = new TimeBlock(new TimeSpan(Hours,Minutes,0));
            appStore.CreateTimeBlock(tbModel);

            CurrentTimeBlock = new TimeBlockViewModel(tbModel);

            foreach (UserTaskViewModel task in SelectedItems) {
                CurrentTimeBlock.AddTask(task);
            }

            CurrentSessionViewModel currentSeshVM = new(appStore);
            appStore.StartTimeBlock(CurrentTimeBlock);

            new Window()
            {
                DataContext = currentSeshVM,
                Content = new CurrentSession()
            }.ShowDialog();

            
        }

 
        private void OnTaskCreated(UserTask task)
        {
            AllTasks.Add(new UserTaskViewModel(task));
        }

        private void OnTaskDeleted(UserTask task)
        {
            UserTaskViewModel toRemove = null;

            foreach (var item in AllTasks)
            {
                if (item.Task == task)
                {
                    toRemove = item;
                }
            }

            if (toRemove == null) return;

            AllTasks.Remove(toRemove);
        }

        public override void Dispose()
        {
            appStore.TaskCreated -= OnTaskCreated;
            appStore.TaskDeleted -= OnTaskDeleted;
            base.Dispose();
        }
    }
}
