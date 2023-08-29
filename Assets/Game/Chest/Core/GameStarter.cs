using UnityEngine;
using VContainer;

namespace Game
{
    public class GameStarter : MonoBehaviour
    {
        [Inject] private RealTimeSaveLoader _saveLoader;
        [Inject] private Scopes.ChestInstaller _chestInstaller;

        private void Start()
        {
            _saveLoader.OnLoadGame();
            _chestInstaller.StartChestsTimer();
        }
    }
}