using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    [CreateAssetMenu(menuName = "Create UpgradesCatalog", fileName = "UpgradesCatalog", order = 0)]
    public sealed class UpgradesCatalog : ScriptableObject
    {
        public IEnumerable<UpgradeConfig> Configs => _configs;

        [SerializeField] private UpgradeConfig[] _configs;
    }
}