using System;
using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    public class TimeReward : MonoBehaviour
    {
        public event Action OnStarted;
        
        [SerializeField] private int _rewardMoney = 100;
        [SerializeField] private float _timeToReceive = 5f;

        [ShowInInspector, ReadOnly]
        private Countdown _timer = new();

        private MoneyStorage _moneyStorage;

        private void Awake()
        {
            _moneyStorage = FindObjectOfType<MoneyStorage>();
            _timer.Duration = _timeToReceive;
            _timer.OnEnded += ReceiveReward;
        }
        
        private void Start()
        {
            _timer.Play();
        }
        
        public float GetRemainingTime()
        {
            return _timer.RemainingTime;
        }
        
        public void SetRemainingTime(float remainingTime)
        {
            _timer.RemainingTime = remainingTime;
        }

        private void ReceiveReward()
        {
            if (_timer.Progress >= 1)
            {
                _moneyStorage.AddMoney(_rewardMoney);
                Debug.Log($"You received reward {_rewardMoney}!");
            }
            else
            {
                Debug.Log("You can't receive reward!");
            }
        }
    }
}
