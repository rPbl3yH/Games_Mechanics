using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.GamePlay.Upgrades
{
    public class UpgradeInstaller : MonoInstaller<UpgradeInstaller>
    {
        [SerializeField] private UpgradesCatalog _catalog;
        private readonly List<Upgrade> _upgrades = new();

        public override void InstallBindings()
        {
            foreach (UpgradeConfig config in _catalog.Configs)
            {
                _upgrades.Add(config.InstantiateUpgrade());
            }

            Container.Bind<UpgradePurchaser>().FromNew().AsSingle();
            Container.Bind<UpgradesManager>().FromNew().AsSingle().WithArguments(_upgrades);
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