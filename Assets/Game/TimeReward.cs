using System;
using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    public class TimeReward : MonoBehaviour
    {
        public event Action OnTimerStarted;

        [SerializeField] private TimeRewardConfig _timeRewardConfig;
        [SerializeField] private TimeRewardReceiver _timeRewardReceiver;

        [ShowInInspector, ReadOnly]
        private Timer _timer = new();

        private void Awake()
        {
            _timer.Duration = _timeRewardConfig.ReceivingTime;
        }

        private void Start()
        {
            StartTimer();
        }

        private void StartTimer()
        {
            _timer.Play();
            
            if (_timer.Progress == 0)
            {
                OnTimerStarted?.Invoke();
            }
        }

        public void SetCurrentTime(float currentTime)
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
                _timeRewardReceiver.ReceiveReward();
                Restart();
            }
            else
            {
                Debug.Log("You can't receive reward!");
            }
        }
    }
}
