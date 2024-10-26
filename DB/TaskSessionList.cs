using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Data;

namespace YourTimeApp.DB
{
    /// <summary>
    /// Stores a list of tasks and TimeBlocks - eventually we will transfer this to a proper DB
    /// </summary>
    public static class TaskSessionList
    {
        public static List<UserTask> Tasks { get;} = new List<UserTask> { };
        public static List<TimeBlock> TimeBlocks { get; } = new List<TimeBlock>();
    }
}
