using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Data;

namespace YourTimeApp.ViewModels
{
    internal class SessionStartedViewModel : ViewModelBase
    {

        private TimeBlock myBlock;



        public SessionStartedViewModel()
        {
			//myBlock = new SessionBlock(TimeSpan.FromMinutes(1));
        }



		public RelayCommand StartTimeCommand => new RelayCommand(execute => { }, canExecute => { return true; });

		private void StartTimer()
		{

		}
	}
}
