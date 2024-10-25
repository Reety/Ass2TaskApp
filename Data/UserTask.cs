using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourTimeApp.Data
{
    public class UserTask
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool isComplete {  get; set; }

        public TimeSpan AllocatedTime { get; set; } = TimeSpan.Zero;
        public TimeSpan TimeSpent { get; set; } = TimeSpan.Zero;

        public UserTask(string taskDesc) { 
            Description = taskDesc;
            isComplete = false;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
