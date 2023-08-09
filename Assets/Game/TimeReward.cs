using System;
using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    public class TimeReward : MonoBehaviour
    {
        public event Action OnTimerStarted;
        
        [SerializeField] private int _rewardMoney = 100;
        [SerializeField] private float _timeToReceive = 5f;

        [ShowInInspector, ReadOnly]
        private Timer _timer = new();

        private MoneyStorage _moneyStorage;

        private void Awake()
        {
            _moneyStorage = FindObjectOfType<MoneyStorage>();
            _timer.Duration = _timeToReceive;
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

        private void Restart()
        {
            _timer.ResetTime();
            StartTimer();
        }

        [Button]
        private void ReceiveReward()
        {
            if (_timer.Progress >= 1)
            {
                _moneyStorage.AddMoney(_rewardMoney);
                Debug.Log($"You received reward {_rewardMoney}!");
                Restart();
            }
            else
            {
                Debug.Log("You can't receive reward!");
            }
        }
    }
}
