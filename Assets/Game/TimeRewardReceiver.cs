using System.Collections.Generic;
using Game.Reward;
using UnityEngine;
using Zenject;

namespace Game
{
    public class TimeRewardReceiver : MonoBehaviour
    {
        [SerializeField] private TimeRewardConfig _config;
        private List<Reward.Reward> _rewards = new();
        private MoneyStorage _moneyStorage;

        [Inject] private DiContainer _container;
        
        private void Awake()
        {
            _rewards = _config.Rewards;
            foreach (var reward in _rewards)
            {
                reward.Construct(_container);
            }
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