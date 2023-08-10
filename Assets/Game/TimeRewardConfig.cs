using System.Collections.Generic;
using Game.Reward;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Assets/Create/New TimeRewardConfig", fileName = "TimeRewardConfig", order = 0)]
    public class TimeRewardConfig : ScriptableObject
    {
        public float ReceivingTime;
        [SerializeReference] public List<IReward> Rewards;
    }
}