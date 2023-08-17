using UnityEngine;

namespace Game.Reward
{
    [CreateAssetMenu(menuName = "Rewards/Create MoneyRewardConfig", fileName = "MoneyRewardConfig", order = 0)]
    public class MoneyRewardConfig : RewardConfig
    {
        public int Money;
        
        public override Reward Create()
        {
            return new MoneyReward(this);
        }
    }
}