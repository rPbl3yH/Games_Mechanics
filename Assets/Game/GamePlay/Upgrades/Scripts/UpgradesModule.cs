using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    public sealed class UpgradesModule : MonoBehaviour
    {
        [SerializeField] private UpgradesCatalog _catalog;
        [SerializeField] private UpgradesModule _upgradesModule;
        [SerializeField] private UpgradePurchaser _upgradePurchaser;
        [Header("Debug")]
        [SerializeField] private string _upgradeID;

        private List<Upgrade> _upgrades;

        private void Awake()
        {
            foreach (UpgradeConfig config in _catalog.Configs)
            {
                _upgrades.Add(config.InstantiateUpgrade());
            } 
        }

        public Upgrade GetUpgradeBy(string id)
        {
            return _upgrades.Find(upgrade => upgrade.Id == id);
        }

        public void Purchase()
        {
            Upgrade upgrade = _upgradesModule.GetUpgradeBy(_upgradeID);
            if (upgrade != null)
            {
                bool purchaseResult = _upgradePurchaser.TryPurchase(upgrade);
                Debug.Log($"Purchase result: {purchaseResult}");
            }
        }
    }
}