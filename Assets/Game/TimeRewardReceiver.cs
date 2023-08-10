using System.Collections.Generic;
using Game.Reward;
using UnityEngine;

namespace Game
{
    public class TimeRewardReceiver : MonoBehaviour
    {
        [SerializeField] private int _moneyReward;
        
        private MoneyStorage _moneyStorage;
        private List<IReward> _rewards = new();

        private void Awake()
        {
            _moneyStorage = FindObjectOfType<MoneyStorage>();
        }

        private void Start()
        {
            _rewards.Add(new MoneyReward(_moneyReward, _moneyStorage));
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