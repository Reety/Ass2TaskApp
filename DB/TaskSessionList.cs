using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Data;

namespace YourTimeApp.DB
{
    public static class TaskSessionList
    {
        public static List<UserTask> Tasks { get;} = new List<UserTask> { };
        public static List<TimeBlock> TimeBlocks { get; } = new List<TimeBlock>();
    }
}
