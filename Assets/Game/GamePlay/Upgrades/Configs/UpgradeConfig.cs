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
}