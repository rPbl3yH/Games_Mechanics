using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game
{
    public class ChestInstaller : MonoInstaller<ChestInstaller>
    {
        [SerializeField] private List<ChestConfig> _chestRewardConfigs;

        [ShowInInspector] private List<Chest> _chests = new();
        private ChestRewardObserver _chestRewardObserver;
        private RealTimeSaveLoader _saveLoader;

        public override void InstallBindings()
        {
            _saveLoader = new RealTimeSaveLoader();
            Container.Bind<RealTimeSaveLoader>()
                .FromInstance(_saveLoader)
                .AsSingle();
            
            _chestRewardObserver = new ChestRewardObserver();
            Container.Bind<ChestRewardObserver>()
                .FromInstance(_chestRewardObserver)
                .AsSingle();
            
            InitializeChest();
        }

        private void InitializeChest()
        {
            foreach (var config in _chestRewardConfigs)
            {
                AddChest(config);
            }
        }

        public void StartChestTimers()
        {
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