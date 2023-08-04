using System;
using Declarative;
using UnityEngine;

namespace AtomicHomework.Atomic.Custom
{
    public class Timer : IUpdateListener
    {
        public event Action OnTimerFinished;
        
        private float _timer;
        private float _targetTime;
        private bool _isEnabled;
        
        public void Update(float deltaTime)
        {
            if (!_isEnabled)
            {
                return;
            }
            
            _timer += deltaTime;
            
            if (_timer >= _targetTime)
            {
                StopTimer();
                OnTimerFinished?.Invoke();
            }
        }

        public void Construct(float targetTime)
        {
            _targetTime = targetTime;
        }

        public void StartTimer()
        {
            _isEnabled = true;
        }

        private void StopTimer()
        {
            _timer = 0;
            _isEnabled = false;
        }
    }
}