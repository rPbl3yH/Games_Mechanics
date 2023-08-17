using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public class ChestRewardInstaller : MonoBehaviour, IInitializable
    {
        [SerializeField] private List<ChestRewardConfig> _chestRewardConfigs;
        [SerializeField] private ChestTimeRewardModule _chestTimeRewardModule;

        public void Initialize()
        {
            foreach (var config in _chestRewardConfigs)
            {
                _chestTimeRewardModule.AddChest(config);
            }
        }
    }
}