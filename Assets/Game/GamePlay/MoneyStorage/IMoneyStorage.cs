using System;
using UnityEngine;

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

    internal class MoneyStorage : MonoBehaviour, IMoneyStorage
    {
        public event Action<int> OnMoneyChanged;
        public event Action<int> OnMoneyEarned;
        public event Action<int> OnMoneySpent;
        public int Money { get; }
        
        public void EarnMoney(int amount)
        {
            Debug.Log("Earn money " + amount);
        }

        public void SpendMoney(int amount)
        {
            Debug.Log("Spend money " + amount);
        }

        public bool CanSpendMoney(int amount)
        {
            var result = amount >= Money;
            Debug.Log($"Can spend money {result}");
            return result;
        }
    }
}