using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    public abstract class UpgradeConfig : ScriptableObject
    {
        public string Id;
        public int MaxLevel;
        public UpgradePriceTable PriceTable = new();

        public abstract Upgrade InstantiateUpgrade();
    }

    [CreateAssetMenu(menuName = "Create LoadStorageUpgradeConfig", fileName = "LoadStorageUpgradeConfig", order = 0)]
    class LoadStorageUpgradeConfig : UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade()
        {
            return new LoadStorageUpgrade(this);
        }
    }
}