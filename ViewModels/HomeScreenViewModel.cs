using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Stores;

namespace YourTimeApp.ViewModels
{
    public class HomeScreenViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
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

        #region New Task Description
        private string _taskDescription;

        public string TaskDescription
        {
            get => _taskDescription;
            set 
            { 
                _taskDescription = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Observable Collection Bindings
        private ObservableCollection<UserTaskViewModel> _tasks;

        public ObservableCollection<UserTaskViewModel> Tasks => _tasks;

        private UserTaskViewModel _selectedTask;
        public UserTaskViewModel SelectedTask
        {
            get => _selectedTask; 
            set
            {
                _selectedTask = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public HomeScreenViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _tasks = [];
        }

        public RelayCommand AddCommand;
        public RelayCommand DeleteCommand;
        public RelayCommand CreateSeshCommand => new RelayCommand(execute => SeshCreator());

        private void SeshCreator()
        {
            _navigationStore.CurrentViewModel = new CreateSessionViewModel();
        }
    }
}
