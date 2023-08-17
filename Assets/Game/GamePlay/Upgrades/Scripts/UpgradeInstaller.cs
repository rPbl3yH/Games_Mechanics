using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.GamePlay.Upgrades
{
    public class UpgradeInstaller : MonoInstaller<UpgradeInstaller>
    {
        [SerializeField] private UpgradesCatalog _catalog;
        [SerializeField] private MoneyStorage _moneyStorage;
        [SerializeField] private UpgradesManager _upgradesManager;
        
        private readonly List<Upgrade> _upgrades = new();

        public override void InstallBindings()
        {
            foreach (UpgradeConfig config in _catalog.Configs)
            {
                _upgrades.Add(config.InstantiateUpgrade());
            }
            
            var purchaser = new UpgradePurchaser(_moneyStorage);
            _upgradesManager.Construct(_upgrades, purchaser);
            Container.Bind<UpgradesManager>().FromInstance(_upgradesManager).AsSingle();
        }

        public override void Start()
        {
            base.Start();
                        
            foreach (var upgrade in _upgrades)
            {
                Container.Inject(upgrade);
            }
        }
    }
}