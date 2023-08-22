using System.Collections.Generic;
using Game.Reward;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Rewards/ChestRewardConfig", fileName = "TimeRewardConfig", order = 0)]
    public class ChestConfig : ScriptableObject
    {
        public string Id;
        public float ReceivingTime;
        [SerializeField] private List<RewardConfig> RewardConfigs;

        public RewardConfig GetRandomReward()
        {
            var randomId = Random.Range(0, RewardConfigs.Count);
            return RewardConfigs[randomId];
        }
    }
}