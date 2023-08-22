using System.Collections.Generic;
using Game.Reward;
using UnityEngine;
using Zenject;

namespace Game
{
    public class ChestRewardObserver 
    {
        private readonly Dictionary<Chest, ChestConfig> _timers = new();

        [Inject] private RewardFactory _rewardFactory;

        public void RegisterChest(Chest timer, ChestConfig config)
        {
            if (_timers.TryAdd(timer, config))
            {
                timer.OnOpened += ReceiveReward;
            }
        }
        
        private void ReceiveReward(Chest chest)
        {
            if (!_timers.TryGetValue(chest, out var configs)) return;

            var config = configs.GetRandomReward();
            var reward = _rewardFactory.Create(config);
            reward.ReceiveReward();
            Debug.Log($"You received reward {reward.GetType()}!");
        }
    }
}