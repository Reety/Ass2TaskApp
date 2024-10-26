using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Data;

namespace YourTimeApp.ViewModels
{
    internal class SessionStartedViewModel : ViewModelBase
    {
        public ObservableCollection<UserTaskViewModel> Tasks { get; set; }
        public SessionStartedViewModel()
        {
            Tasks = CreateTaskViewModel.Tasks;
                  
        }



		public RelayCommand StartTimeCommand => new RelayCommand(execute => { }, canExecute => { return true; });

		private void StartTimer()
		{

		}
	}
}
