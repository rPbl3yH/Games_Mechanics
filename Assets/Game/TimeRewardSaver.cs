using System;
using UnityEngine;

namespace Game
{
    public class TimeRewardSaver : MonoBehaviour
    {
        [SerializeField] private TimeReward _timeReward;

        private readonly string _key = nameof(TimeReward);

        private void Awake()
        {
            _timeReward.OnStarted += OnStarted;
        }

        private void OnStarted()
        {
            PlayerPrefs.SetFloat(_key, _timeReward.GetRemainingTime());
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey(_key))
            {
                var currentTime = DateTime.Now;
                var pastTime = PlayerPrefs.GetFloat(_key);
                   
                _timeReward.SetRemainingTime(PlayerPrefs.GetFloat(_key));
            }
        }
    }
}