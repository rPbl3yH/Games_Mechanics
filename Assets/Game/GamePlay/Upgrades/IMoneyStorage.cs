using System;

namespace Game.GamePlay.Upgrades
{
    public interface IMoneyStorage
    {
        event Action<int> OnMoneyChanged;
        event Action<int> OnMoneyEarned;
        event Action<int> OnMoneySpent;

        int Money { get; }

        void EarnMoney(int amount);
        void SpendMoney(int amount);
 
        bool CanSpendMoney(int amount);
    }
}