namespace Game.Reward
{
    public interface IReward
    {
        void ReceiveReward();
    }

    class MoneyReward : IReward
    {
        private readonly int _money;
        private readonly MoneyStorage _moneyStorage;

        public MoneyReward(int money, MoneyStorage moneyStorage)
        {
            _money = money;
            _moneyStorage = moneyStorage;
        }

        public void ReceiveReward()
        {
            _moneyStorage.AddMoney(_money);
        }
    }
}