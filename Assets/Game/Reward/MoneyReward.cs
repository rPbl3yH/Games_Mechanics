using UnityEngine;
using Zenject;

namespace Game.Reward
{
    
    public class MoneyReward : Reward
    {
        private readonly int _money;
        [Inject] private MoneyStorage _moneyStorage;

        public MoneyReward(MoneyRewardConfig config)
        {
            _money = config.Money;
        }

        public override void ReceiveReward()
        {
            Debug.Log("get money");
            _moneyStorage.AddMoney(_money);
        }
    }
}