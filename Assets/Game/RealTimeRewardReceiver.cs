using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public class RealTimeRewardReceiver 
    {
        private readonly Dictionary<IRealtimeTimer, TimeRewardConfig> _timers = new();

        [Inject] private DiContainer _container;

        public void RegisterTimer(IRealtimeTimer timer, TimeRewardConfig config)
        {
            if (_timers.TryAdd(timer, config))
            {
                foreach (var reward in config.Rewards)
                {
                    reward.Construct(_container);
                }
                
                timer.OnFinished += ReceiveReward;
            }
        }
        
        private void ReceiveReward(IRealtimeTimer timer)
        {
            if (!_timers.TryGetValue(timer, out var config)) return;
            
            foreach (var reward in config.Rewards)
            {
                reward.ReceiveReward();
                Debug.Log($"You received reward {reward.GetType()}!");
            }
        }
    }
}