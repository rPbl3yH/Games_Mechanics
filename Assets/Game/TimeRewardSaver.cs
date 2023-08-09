using System;
using UnityEngine;

namespace Game
{
    public class TimeRewardSaver : MonoBehaviour
    {
        [SerializeField] private TimeReward _timeReward;

        private readonly string _key = nameof(TimeReward);
        
        private void Start()
        {
            if (PlayerPrefs.HasKey(_key))
            {
                _timeReward.SetTimeProgress(PlayerPrefs.GetFloat(_key));
            }
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.SetFloat(_key, _timeReward.GetCurrentProgress());
        }
    }
}