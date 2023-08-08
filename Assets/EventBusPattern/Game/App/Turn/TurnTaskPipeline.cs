using System;
using System.Collections.Generic;

namespace EventBusPattern
{
    public class TurnTaskPipeline
    {
        public event Action OnFinished;

        private List<Task> _tasks = new();

        private int _currentIndex = -1;

        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }
        
        public void Run()
        {
            _currentIndex = 0;
            RunNextTask();
        }

        private void RunNextTask()
        {
            if (_currentIndex >= _tasks.Count)
            {
                OnFinished?.Invoke();
                return;
            }

            _tasks[_currentIndex].Run(OnTaskFinished);
        }

        private void OnTaskFinished(Task task)
        {
            _currentIndex++;
            RunNextTask();
        }
    }
}