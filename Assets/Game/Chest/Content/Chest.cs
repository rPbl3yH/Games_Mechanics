using System;
using System.Collections.Generic;
using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class Chest : IRealtimeTimer
    {
        public event Action<IRealtimeTimer> OnStarted;
        public event Action<Chest> OnFinished;
        public string Id => nameof(Chest);

        [ShowInInspector, ReadOnly]
        private Timer _timer = new();

        public Chest(ChestRewardConfig chestRewardConfig)
        {
            _timer.Duration = chestRewardConfig.ReceivingTime;
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

        private bool CanOpen()
        {
            return _timer.Progress >= 1;
        }
        
        private void Restart()
        {
            _timer.ResetTime();
            StartTimer();
        }

        [Button]
        private void Open()
        {
            if (CanOpen())
            {
                OnFinished?.Invoke(this);
                Restart();
            }
            else
            {
                Debug.Log("You can't receive reward!");
            }
        }
    }
}
