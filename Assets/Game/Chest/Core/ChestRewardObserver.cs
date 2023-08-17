using System.Collections.Generic;
using Game.Reward;
using UnityEngine;
using Zenject;

namespace Game
{
    public class ChestRewardObserver 
    {
        private readonly Dictionary<Chest, ChestRewardConfig> _timers = new();

        [Inject] private RewardFactory _rewardFactory;

        public void RegisterChest(Chest timer, ChestRewardConfig config)
        {
            if (_timers.TryAdd(timer, config))
            {
                timer.OnFinished += ReceiveReward;
            }
        }
        
        private void ReceiveReward(Chest chest)
        {
            if (!_timers.TryGetValue(chest, out var configs)) return;

            var config = configs.GetRandom();
            var reward = _rewardFactory.Create(config);
            reward.ReceiveReward();
            Debug.Log($"You received reward {reward.GetType()}!");
        }
    }
}