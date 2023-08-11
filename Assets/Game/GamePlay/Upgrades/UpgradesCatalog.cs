using System.Collections.Generic;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    public sealed class UpgradesCatalog : ScriptableObject
    {
        public IEnumerable<UpgradeConfig> Configs => _configs;

        [SerializeField] private UpgradeConfig[] _configs;
    }
}