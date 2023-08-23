using Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Game.GamePlay.Upgrades
{
    public class UpgradeDebug : MonoBehaviour
    {

        [Header("Debug")] 
        [SerializeField] private string _upgradeId;

        private IMoneyStorage _moneyStorage;
        private UpgradesManager _upgradesManager;

        [Inject]
        public void Construct(IMoneyStorage moneyStorage, UpgradesManager upgradesManager) {
            Debug.Log("Inject in upgrade debug");
            _moneyStorage = moneyStorage;
            _upgradesManager = upgradesManager;
        }
        
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