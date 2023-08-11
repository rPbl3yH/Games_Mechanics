using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    [CreateAssetMenu(menuName = "Create LoadStorageUpgradeConfig", fileName = "LoadStorageUpgradeConfig", order = 0)]
    class LoadStorageUpgradeConfig : UpgradeConfig
    {
        public LoadStorageUpgradeTable StorageUpgradeTable;
        
        public override Upgrade InstantiateUpgrade()
        {
            return new LoadStorageUpgrade(this);
        }

        private void OnValidate()
        {
            StorageUpgradeTable.OnValidate(MaxLevel);
        }
    }
}