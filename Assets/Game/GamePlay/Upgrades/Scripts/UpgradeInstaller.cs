using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.GamePlay.Upgrades
{
    public class UpgradeInstaller : MonoInstaller<UpgradeInstaller>
    {
        [SerializeField] private UpgradesCatalog _catalog;
        [SerializeField] private MoneyStorage _moneyStorage;
        private UpgradesManager _upgradesManager;
        
        private readonly List<Upgrade> _upgrades = new();

        public override void InstallBindings()
        {
            foreach (UpgradeConfig config in _catalog.Configs)
            {
                _upgrades.Add(config.InstantiateUpgrade());
            }
            
            var purchaser = new UpgradePurchaser(_moneyStorage);
            Container.Bind<UpgradesManager>().FromNew().AsSingle().WithArguments(_upgrades, purchaser);
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