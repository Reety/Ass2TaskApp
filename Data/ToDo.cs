using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourTimeApp.Data
{
    public class ToDo
    {
        public int Id { get; set; }
        public string? TaskDesc { get; set; }
        public bool isComplete {  get; set; }

        public TimeSpan TimeEstimated { get; set; }
        public TimeSpan TimeSpent { get; }

        public ToDo(string taskDesc) { 
            TaskDesc = taskDesc;
            TimeSpent = TimeSpan.Zero;
            TimeEstimated = TimeSpan.Zero;
            isComplete = false;
        }

        public override string ToString()
        {
            return TaskDesc;
        }
    }
}
