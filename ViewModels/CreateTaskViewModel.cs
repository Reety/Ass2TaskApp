﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Data;
using YourTimeApp.DB;

namespace YourTimeApp.ViewModels
{
    internal class CreateTaskViewModel : ViewModelBase
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

        private int seconds;
        public int Seconds
        {
            get => seconds;
            set
            {
                seconds = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private string taskDescription;

        public string TaskDescription
        {
            get { return taskDescription; }
            set { taskDescription = value;
                OnPropertyChanged();
            }
        }

        public static ObservableCollection<UserTaskViewModel> Tasks { get; set; } = [];

        private YourTimeStore appStore;

        public RelayCommand AddCommand => new RelayCommand(execute => AddTask(),canExecute => !(TaskDescription == null || TaskDescription == string.Empty));
        public RelayCommand CreateSeshCommand => new RelayCommand(execute => CreateSesh());
        public CreateTaskViewModel(YourTimeStore appStore)
        {
            TaskSessionList.Tasks.ForEach(t => Tasks.Add(new UserTaskViewModel(t)));
            this.appStore = appStore;
            appStore.TaskCreated += OnTaskCreation;
        }

        private void CreateSesh()
        {
            SessionStart sessionStart = new SessionStart()
            {
                DataContext = new SessionStartViewModel(appStore)
            };

            sessionStart.Show();
        }
        private void AddTask()
        {
            UserTask newTask = new UserTask(TaskDescription)
            {
                AllocatedTime = new TimeSpan(Hours, Minutes, Seconds)
            };

            appStore.CreateTask(newTask);

            Hours = 0; Minutes = 0; Seconds = 0; TaskDescription = string.Empty;
        }

        private void OnTaskCreation(UserTask task)
        {
            Tasks.Add(new UserTaskViewModel(task));
        }

        public override void Dispose()
        {
            appStore.TaskCreated -= OnTaskCreation;
            base.Dispose();
        }

    }
}
