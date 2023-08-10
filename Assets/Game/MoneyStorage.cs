using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    public class MoneyStorage 
    {
        [ShowInInspector,ReadOnly]
        private int _money;
        
        public void AddMoney(int money)
        {
            _money += money;
        }
    }
}