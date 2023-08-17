using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    public sealed class UpgradesManager : MonoBehaviour
    {
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

        public void Purchase(string upgradeId)
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