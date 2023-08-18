using System.Collections.Generic;
using Game.Reward;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Rewards/ChestRewardConfig", fileName = "TimeRewardConfig", order = 0)]
    public class ChestRewardConfig : ScriptableObject
    {
        public string Id;
        public float ReceivingTime;
        public List<RewardConfig> RewardConfigs;

        public RewardConfig GetRandom()
        {
            var randomId = Random.Range(0, RewardConfigs.Count);
            return RewardConfigs[randomId];
        }
    }
}