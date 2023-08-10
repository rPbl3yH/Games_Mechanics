using Zenject;

namespace Game.Reward
{
    class MoneyReward : Reward
    {
        public int Money;
        private MoneyStorage _moneyStorage;

        public override void Construct(DiContainer container)
        {
            _moneyStorage = container.Resolve<MoneyStorage>();
        }

        public override void ReceiveReward()
        {
            _moneyStorage.AddMoney(Money);
        }
    }
}