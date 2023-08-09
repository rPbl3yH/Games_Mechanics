using System;
using System.Collections.Generic;

namespace EventBusPattern.Visual
{
    public class VisualTaskPipeline
    {
        public event Action OnFinished;

        private List<VisualTask> _tasks = new();

        private int _currentIndex = -1;

        public void AddTask(VisualTask task)
        {
            _tasks.Add(task);
        }

        public void Clear()
        {
            _tasks.Clear();
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