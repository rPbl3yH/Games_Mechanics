using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameStarter : MonoBehaviour
    {
        [Inject] private RealTimeSaveLoader _saveLoader;
        [Inject] private ChestInstaller _chestInstaller; 
        
        private void Start()
        {
            _saveLoader.OnLoadGame();
            _chestInstaller.StartChestTimers();
        }
    }
}