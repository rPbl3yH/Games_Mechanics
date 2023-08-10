using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public class TimeRewardReceiver : MonoBehaviour
    {
        private List<Reward.Reward> _rewards = new();

        [Inject] private DiContainer _container;

        public void Construct(TimeRewardConfig config, IRealtimeTimer timer)
        {
            _rewards = config.Rewards;
            foreach (var reward in _rewards)
            {
                reward.Construct(_container);
            }
            
            timer.OnFinish += ReceiveReward;
        }

        private void ReceiveReward(IRealtimeTimer timer)
        {
            foreach (var reward in _rewards)
            {
                reward.ReceiveReward();
                Debug.Log($"You received reward {reward.GetType()}!");
            }
        }
    }
}