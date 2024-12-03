using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Data;
using YourTimeApp.DB;
using YourTimeApp.ViewModels;

namespace YourTimeApp.Data

{
    public class YourTimeStore
    {
        public event Action<UserTask> TaskCreated;
        public event Action<UserTask> TaskDeleted;
        public event Action<TimeBlock> TimeBlockCreated;
        public event Action<TimeBlockViewModel> TimeBlockFinished;
        public event Action<TimeBlockViewModel> TimeBlockStarted;

        public void CreateTask(UserTask task)
        {
            TaskSessionList.Tasks.Add(task);
            TaskCreated?.Invoke(task);
        }

        public void CreateTimeBlock(TimeBlock timeBlock)
        {
            TaskSessionList.TimeBlocks.Add(timeBlock);
            TimeBlockCreated?.Invoke(timeBlock);
        }

        public void DeleteTask(UserTask task)
        {
            TaskSessionList.Tasks.Remove(task);
            TaskDeleted?.Invoke(task);
        }

        public void EndTimeBlock(TimeBlockViewModel timeBlock)
        {
            TimeBlockFinished?.Invoke(timeBlock);
        }

        public void StartTimeBlock(TimeBlockViewModel timeBlock) { TimeBlockStarted?.Invoke(timeBlock); }
    }
}
