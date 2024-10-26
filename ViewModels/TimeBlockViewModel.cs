using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Data;

namespace YourTimeApp.ViewModels
{
    internal class TimeBlockViewModel : ViewModelBase
    {
        public TimeBlock TimeBlock;

        public ObservableCollection<(UserTaskViewModel taskViewModel, TimeSpan)> TaskTimes;
        public TimeBlockViewModel(TimeBlock timeBlock)
        {
            TimeBlock = timeBlock;
        }
    }
}
