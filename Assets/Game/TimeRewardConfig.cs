using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Assets/Create/New TimeRewardConfig", fileName = "TimeRewardConfig", order = 0)]
    public class TimeRewardConfig : ScriptableObject
    {
        public float ReceivingTime;
        [SerializeReference] public List<Reward.Reward> Rewards;
    }
}