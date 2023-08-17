using System.Collections.Generic;
using Game.Reward;
using UnityEngine;
using Zenject;

namespace Game
{
    public class RealTimeRewardReceiver 
    {
        private readonly Dictionary<IRealtimeTimer, TimeRewardConfig> _timers = new();

        [Inject] private RewardFactory _rewardFactory;

        public void RegisterTimer(IRealtimeTimer timer, TimeRewardConfig config)
        {
            if (_timers.TryAdd(timer, config))
            {
                timer.OnFinished += ReceiveReward;
            }
        }
        
        private void ReceiveReward(IRealtimeTimer timer)
        {
            if (!_timers.TryGetValue(timer, out var configs)) return;
            
            foreach (var config in configs.RewardConfigs)
            {
                var reward = _rewardFactory.Create(config);
                reward.ReceiveReward();
                Debug.Log($"You received reward {reward.GetType()}!");
            }
        }
    }
}