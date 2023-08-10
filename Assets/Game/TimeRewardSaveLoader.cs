using System;
using System.Globalization;
using UnityEngine;

namespace Game
{
    public class TimeRewardSaveLoader : MonoBehaviour
    {
        [SerializeField] private TimeReward _timeReward;

        private readonly string _key = nameof(TimeReward);

        private void Awake()
        {
            _timeReward.OnStarted += TimerStarted;
            LoadTime();
        }

        private void TimerStarted(IRealtimeTimer obj)
        {
            SaveTime();
        }

        private void SaveTime()
        {
            Debug.Log("Save time");
            PlayerPrefs.SetString(_key, DateTime.Now.ToString(CultureInfo.InvariantCulture));
        }

        private void LoadTime()
        {
            if (PlayerPrefs.HasKey(_key))
            {
                var serializedTime = PlayerPrefs.GetString(_key);
                var previousTime = DateTime.Parse(serializedTime, CultureInfo.InvariantCulture);
                var timeSpan = DateTime.Now - previousTime;
                var pauseSeconds = timeSpan.TotalSeconds;  
                Debug.Log("Pause seconds = " + pauseSeconds);
                _timeReward.Synchronize((float)pauseSeconds);
            }
        }
    }
}