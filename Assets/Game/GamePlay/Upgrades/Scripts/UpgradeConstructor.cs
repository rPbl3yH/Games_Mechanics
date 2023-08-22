using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.GamePlay.Upgrades
{
    public class UpgradeConstructor : MonoBehaviour, IStartable
    {
        [SerializeField] private UpgradesCatalog _catalog;

        private readonly List<Upgrade> _upgrades = new();
        private IContainerBuilder _builder;

        public void Construct(IContainerBuilder builder)
        {
            foreach (UpgradeConfig config in _catalog.Configs)
            {
                _upgrades.Add(config.InstantiateUpgrade());
            }

            builder.Register<UpgradePurchaser>(Lifetime.Singleton);
            builder.Register<UpgradesManager>(Lifetime.Singleton).WithParameter(_upgrades);
            _builder = builder;
        }

        public void Start()
        {
            foreach (var upgrade in _upgrades)
            {
                //Container.Inject(upgrade);
            }
        }
    }
}