using System.Collections.Generic;
using System.Linq;

namespace Game.GamePlay.Upgrades
{
    public sealed class UpgradesContext
    {
        private readonly UpgradesCatalog _catalog;
        private List<Upgrade> _upgrades;

        public UpgradesContext(UpgradesCatalog catalog) => 
            _catalog = catalog;

        public void Init()
        {
            IEnumerable<UpgradeConfig> configs = _catalog.Configs;
            _upgrades = new List<Upgrade>(configs.Count());
            
            foreach (UpgradeConfig config in configs) 
                _upgrades.Add(config.InstantiateUpgrade());
        }

        public Upgrade GetUpgradeBy(string id) => 
            _upgrades.Find(upgrade => upgrade.Id == id);
    }
}