using System;
using Declarative;

namespace Game.App.Atomic.Custom
{
    public class Timer : IUpdateListener
    {
        public event Action OnTimerFinished;
        
        private float _timer;
        private float _targetTime;
        public bool IsPlaying;
        
        public void Update(float deltaTime)
        {
            if (!IsPlaying)
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
            IsPlaying = true;
        }

        private void StopTimer()
        {
            _timer = 0;
            IsPlaying = false;
        }
    }
}