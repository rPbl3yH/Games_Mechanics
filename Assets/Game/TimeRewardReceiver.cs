using System.Collections.Generic;
using Game.Reward;
using UnityEngine;

namespace Game
{
    public class TimeRewardReceiver : MonoBehaviour
    {
        [SerializeField] private TimeRewardConfig _config;
        private List<IReward> _rewards = new();
        private MoneyStorage _moneyStorage;

        private void Awake()
        {
            _rewards = _config.Rewards;
            _moneyStorage = FindObjectOfType<MoneyStorage>();
        }

        private void Start()
        {
            _rewards.Add(new MoneyReward(100, _moneyStorage));
        }

        public void ReceiveReward()
        {
            foreach (var reward in _rewards)
            {
                reward.ReceiveReward();
                Debug.Log($"You received reward {reward.GetType()}!");
            }
        }
    }
}