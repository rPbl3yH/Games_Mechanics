using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    public class UpgradeDebug : MonoBehaviour
    {
        [SerializeField] private MoneyStorage _moneyStorage;

        [Header("Debug")] 
        [SerializeField] private string _upgradeId;

        [SerializeField] private UpgradesManager _upgradesManager;
        
        [Button]
        public void PurchaseDebug()
        {
            _upgradesManager.Purchase(_upgradeId);
        }

        [Button]
        public void IncreaseMoney(int money)
        {
            _moneyStorage.EarnMoney(money);
        }
    }
}