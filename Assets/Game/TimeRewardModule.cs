using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game
{
    public class TimeRewardModule : MonoBehaviour, IInitializable
    {
        [ShowInInspector] private TimeReward _timeReward = new();
        [SerializeField] private TimeRewardConfig _timeRewardConfig;
        [Inject] private RealTimeRewardReceiver _realTimeRewardReceiver;
        [Inject] private RealTimeSaveLoader _saveLoader;
        
        [Header("Debug")]
        [ShowInInspector] 
        [Inject] private MoneyStorage _moneyStorage;
        
        public void Initialize()
        {
            _timeReward.Construct(_timeRewardConfig);
            _realTimeRewardReceiver.RegisterTimer(_timeReward, _timeRewardConfig);
            _saveLoader.RegisterTimer(_timeReward);
        }

        private void Start()
        {
            _saveLoader.OnLoadGame();
            _timeReward.Start();
        }
    }
}