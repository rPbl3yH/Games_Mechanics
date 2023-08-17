using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    public sealed class UpgradesManager
    {
        private readonly List<Upgrade> _upgrades;
        private readonly UpgradePurchaser _upgradePurchaser;

        public UpgradesManager(List<Upgrade> upgrades, UpgradePurchaser upgradePurchaser)
        {
            _upgrades = upgrades;
            _upgradePurchaser = upgradePurchaser;
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