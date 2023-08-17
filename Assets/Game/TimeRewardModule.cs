using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game
{
    public class TimeRewardModule : MonoBehaviour, IInitializable
    {
        [ShowInInspector] private Chest _chest = new();
        [SerializeField] private ChestRewardConfig _chestRewardConfig;
        [Inject] private ChestRewardObserver _chestRewardObserver;
        [Inject] private RealTimeSaveLoader _saveLoader;
        
        [Header("Debug")]
        [ShowInInspector] 
        [Inject] private MoneyStorage _moneyStorage;
        
        public void Initialize()
        {
            _chest.Construct(_chestRewardConfig);
            _chestRewardObserver.RegisterChest(_chest, _chestRewardConfig);
            _saveLoader.RegisterTimer(_chest);
        }

        private void Start()
        {
            _saveLoader.OnLoadGame();
            _chest.Start();
        }
    }
}