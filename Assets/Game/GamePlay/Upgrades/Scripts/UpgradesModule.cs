using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.GamePlay.Upgrades
{
    public sealed class UpgradesModule : MonoBehaviour
    {
        [SerializeField] private UpgradesCatalog _catalog;
        [SerializeField] private UpgradePurchaser _upgradePurchaser;
        [SerializeField] private MoneyStorage _moneyStorage;
        
        private readonly List<Upgrade> _upgrades = new();

        [Header("Debug")] 
        [SerializeField] private string _upgradeId;

        [Inject] private DiContainer _container;
        
        private void Awake()
        {
            _upgradePurchaser.Construct(_moneyStorage);
            foreach (UpgradeConfig config in _catalog.Configs)
            {
                _upgrades.Add(config.InstantiateUpgrade());
            }

            foreach (var upgrade in _upgrades)
            {
                _container.Inject(upgrade);
            }
        }

        public Upgrade GetUpgradeBy(string id)
        {
            if (_upgrades.Any(upgrade => upgrade.Id == id))
            {
                return _upgrades.Find(upgrade => upgrade.Id == id);
            }
            
            Debug.Log("Upgrade didn't find");
            return null;
        }

        [Button]
        public void IncreaseMoney(int money)
        {
            _moneyStorage.EarnMoney(money);
        }

        [Button]
        public void PurchaseDebug()
        {
            Purchase(_upgradeId);
        }

        public void Purchase(string upgradeId)
        {
            Upgrade upgrade = GetUpgradeBy(upgradeId);
            if (upgrade != null)
            {
                bool purchaseResult = _upgradePurchaser.TryPurchase(upgrade);
                Debug.Log($"Purchase result: {purchaseResult}");
            }
        }
    }
}