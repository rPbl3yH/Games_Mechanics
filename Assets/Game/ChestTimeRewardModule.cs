using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game
{
    public class ChestTimeRewardModule : MonoBehaviour
    {
        [ShowInInspector] private List<Chest> _chests = new();
        [Inject] private ChestRewardObserver _chestRewardObserver;
        [Inject] private RealTimeSaveLoader _saveLoader;

        public void AddChest(ChestRewardConfig config)
        {
            var chest = new Chest(config);
            _chestRewardObserver.RegisterChest(chest, config);
            _saveLoader.RegisterTimer(chest);
            _chests.Add(chest);
        }

        private void Start()
        {
            _saveLoader.OnLoadGame();
            
            foreach (var chest in _chests)
            {
                chest.Start();
            }
        }
    }
}