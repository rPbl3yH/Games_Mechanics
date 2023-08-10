using System;
using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class TimeReward : IRealtimeTimer
    {
        public event Action<IRealtimeTimer> OnStarted;
        public event Action<IRealtimeTimer> OnFinish;
        public string Id => nameof(TimeReward);

        [ShowInInspector, ReadOnly]
        private Timer _timer = new();

        public void Construct(TimeRewardConfig timeRewardConfig)
        {
            _timer.Duration = timeRewardConfig.ReceivingTime;
        }

        public void Start()
        {
            StartTimer();
        }

        private void StartTimer()
        {
            _timer.Play();
            
            if (_timer.Progress == 0)
            {
                OnStarted?.Invoke(this);
            }
        }

        public void Synchronize(float currentTime)
        {
            _timer.CurrentTime = currentTime;
        }

        private bool CanReceiveReward()
        {
            return _timer.Progress >= 1;
        }
        
        private void Restart()
        {
            _timer.ResetTime();
            StartTimer();
        }

        [Button]
        private void ReceiveReward()
        {
            if (CanReceiveReward())
            {
                OnFinish?.Invoke(this);
                Restart();
            }
            else
            {
                Debug.Log("You can't receive reward!");
            }
        }
    }
}
