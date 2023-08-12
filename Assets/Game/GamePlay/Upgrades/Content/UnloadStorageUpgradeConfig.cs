using UnityEngine;

namespace Game.GamePlay.Upgrades.Content
{
    [CreateAssetMenu(menuName = "Create UnloadStorageUpgradeConfig", fileName = "UnloadStorageUpgradeConfig", order = 0)]
    public class UnloadStorageUpgradeConfig : UpgradeConfig
    {
        public UnloadStorageUpgradeTable StorageUpgradeTable;
        
        public override Upgrade InstantiateUpgrade()
        {
            return new UnloadStorageUpgrade(this);
        }

        private void OnValidate()
        {
            StorageUpgradeTable.OnValidate(MaxLevel);
        }
    }
}