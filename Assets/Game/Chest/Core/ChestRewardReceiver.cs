using System;
using System.Collections.Generic;
using Game.Reward;
using UnityEngine;
using VContainer;

namespace Game
{
    public class ChestRewardReceiver 
    {
        private readonly Dictionary<Chest, ChestConfig> _timers = new();

        [Inject]
        private Func<RewardConfig, Reward.Reward> _rewardFactory;

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

            if(_rewardFactory == null)
            {
                Debug.Log("Reward factory is null");
            }

            Debug.Log("Config " + config);
            var reward = _rewardFactory.Invoke(config);
            reward.ReceiveReward();
            Debug.Log($"You received reward {reward.GetType()}!");
        }
    }
}