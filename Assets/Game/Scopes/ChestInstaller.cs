using System.Collections.Generic;
using Game;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scopes
{
    public class ChestInstaller : MonoBehaviour, IInitializable
    {
        [SerializeField] private List<ChestConfig> _chestRewardConfigs;
        [ShowInInspector] private List<Chest> _chests = new();

        [Inject] private ChestRewardReceiver _chestRewardObserver;
        [Inject] private RealTimeSaveLoader _saveLoader;

        public void Initialize()
        {
            foreach (var config in _chestRewardConfigs)
            {
                AddChest(config);
            }
        }

        public void StartChestsTimer()
        {
            Debug.Log("Start chest timer");
            foreach (var chest in _chests)
            {
                chest.Start();
            }
        }

        private void AddChest(ChestConfig config)
        {
            var chest = new Chest(config);
            _chestRewardObserver.RegisterChest(chest, config);
            _saveLoader.RegisterTimer(chest);
            _chests.Add(chest);
        }
    }
}
