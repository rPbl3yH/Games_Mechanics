using System.Collections.Generic;
using Entities;
using Game.GamePlay.Upgrades;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.GamePlay.GameEngine
{
	public class GameLifeTimeScope : LifetimeScope
    {

		[SerializeField] private UpgradesCatalog _catalog;
		private readonly List<Upgrade> _upgrades = new();

        protected override void Configure(IContainerBuilder builder)
		{
			ConfigureSystem(builder);
			ConfigureUpgrades(builder);
		}

		private static void ConfigureSystem(IContainerBuilder builder)
		{
			builder.RegisterComponentInHierarchy<MonoEntity>().As<IEntity>();
			builder.RegisterComponentInHierarchy<MoneyStorage>().As<IMoneyStorage>();
		}

		private void ConfigureUpgrades(IContainerBuilder builder) {

			foreach (UpgradeConfig config in _catalog.Configs) {
				var upgrade = config.InstantiateUpgrade();
                _upgrades.Add(upgrade);
			}

			builder.Register<UpgradePurchaser>(Lifetime.Singleton);
			builder.Register<UpgradesManager>(Lifetime.Singleton).WithParameter(_upgrades);

			builder.RegisterBuildCallback(objectResolver =>
			{
				foreach (var upgrade in _upgrades)
				{
					objectResolver.Inject(upgrade);
				}
			});
		}
    }
}