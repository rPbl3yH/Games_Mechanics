using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    public sealed class UpgradesModule : MonoBehaviour
    {
        [SerializeField] private UpgradesCatalog _catalog;
        [SerializeField] private UpgradePurchaser _upgradePurchaser;
        [SerializeField] private MoneyStorage _moneyStorage;
        [Header("Debug")]
        [SerializeField] private string _upgradeID;

        private readonly List<Upgrade> _upgrades = new();

        private void Awake()
        {
            _upgradePurchaser.Construct(_moneyStorage);
            foreach (UpgradeConfig config in _catalog.Configs)
            {
                _upgrades.Add(config.InstantiateUpgrade());
            } 
        }

        public Upgrade GetUpgradeBy(string id)
        {
            return _upgrades.Find(upgrade => upgrade.Id == id);
        }

        [Button]
        public void Purchase()
        {
            Upgrade upgrade = GetUpgradeBy(_upgradeID);
            if (upgrade != null)
            {
                bool purchaseResult = _upgradePurchaser.TryPurchase(upgrade);
                Debug.Log($"Purchase result: {purchaseResult}");
            }
        }
    }
}