using UnityEngine;
using Zenject;

namespace Game
{
    public class TimeRewardModule : MonoBehaviour, IInitializable
    {
        [SerializeField] private TimeReward _timeReward;
        [SerializeField] private TimeRewardConfig _timeRewardConfig;

        [SerializeField] private TimeRewardSaveLoader _saveLoader;
        
        public void Initialize()
        {
            _timeReward.Construct();
            _saveLoader.Construct(_timeReward);
        }
    }
}