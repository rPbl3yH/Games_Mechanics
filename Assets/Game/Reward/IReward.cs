using Zenject;

namespace Game.Reward
{
    public interface IReward
    {
        void ReceiveReward();
    }

    class MoneyReward : IReward
    {
        public int Money;
        private readonly MoneyStorage _moneyStorage;

        public MoneyReward(int money, MoneyStorage moneyStorage)
        {
            Money = money;
            _moneyStorage = moneyStorage;
        }

        public void ReceiveReward()
        {
            _moneyStorage.AddMoney(Money);
        }
    }
}