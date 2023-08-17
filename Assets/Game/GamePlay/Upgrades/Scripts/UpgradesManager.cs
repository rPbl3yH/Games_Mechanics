using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    public sealed class UpgradesManager : MonoBehaviour
    {
        [SerializeField] private MoneyStorage _moneyStorage;

        [Header("Debug")] 
        [SerializeField] private string _upgradeId;

        private List<Upgrade> _upgrades;
        private UpgradePurchaser _upgradePurchaser;

        public void Construct(List<Upgrade> upgrades, UpgradePurchaser purchaser)
        {
            _upgrades = upgrades;
            _upgradePurchaser = purchaser;
        }
        
        private Upgrade GetUpgrade(string id)
        {
            if (_upgrades.Any(upgrade => upgrade.Id == id))
            {
                return _upgrades.Find(upgrade => upgrade.Id == id);
            }
            
            Debug.Log("Upgrade didn't find");
            return null;
        }

        [Button]
        public void PurchaseDebug()
        {
            Purchase(_upgradeId);
        }

        [Button]
        public void IncreaseMoney(int money)
        {
            _moneyStorage.EarnMoney(money);
        }

        private void Purchase(string upgradeId)
        {
            Upgrade upgrade = GetUpgrade(upgradeId);
            if (upgrade != null)
            {
                bool purchaseResult = _upgradePurchaser.TryPurchase(upgrade);
                Debug.Log($"Purchase result: {purchaseResult}");
            }
        }
    }
}