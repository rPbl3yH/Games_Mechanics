using System;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
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