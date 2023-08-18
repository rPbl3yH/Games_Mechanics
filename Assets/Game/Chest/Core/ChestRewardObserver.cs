using System.Collections.Generic;
using Game.Reward;
using UnityEngine;
using Zenject;

namespace Game
{
    public class ChestRewardObserver 
    {
        private readonly Dictionary<TimeRewardChest, ChestRewardConfig> _timers = new();

        [Inject] private RewardFactory _rewardFactory;

        public void RegisterChest(TimeRewardChest timer, ChestRewardConfig config)
        {
            if (_timers.TryAdd(timer, config))
            {
                timer.OnFinished += ReceiveReward;
            }
        }
        
        private void ReceiveReward(TimeRewardChest timeRewardChest)
        {
            if (!_timers.TryGetValue(timeRewardChest, out var configs)) return;

            var config = configs.GetRandom();
            var reward = _rewardFactory.Create(config);
            reward.ReceiveReward();
            Debug.Log($"You received reward {reward.GetType()}!");
        }
    }
}