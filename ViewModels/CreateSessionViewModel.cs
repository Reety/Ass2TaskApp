using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourTimeApp.ViewModels
{
    public class CreateSessionViewModel : ViewModelBase
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
        public TimeBlockViewModel? CurrentTimeBlock
        {
            get => currentTimeBlock;
            set
            {
                currentTimeBlock = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UserTaskViewModel> AllTasks { get; set; } = [];
        public ObservableCollection<UserTaskViewModel> SelectedItems { get; set; } = [];

        public CreateSessionViewModel()
        {

        }
    }
}
