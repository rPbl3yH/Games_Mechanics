using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Game
{
    public class RealTimeSaveLoader
    {
        private readonly HashSet<IRealtimeTimer> timers = new();

        public void RegisterTimer(IRealtimeTimer timer)
        {
            if (this.timers.Add(timer))
            {
                timer.OnStarted += this.SaveTimer;
            }
        }

        public void UnregisterTimer(IRealtimeTimer timer)
        {
            if (this.timers.Add(timer))
            {
                timer.OnStarted -= this.SaveTimer;
            }
        }

        public void OnLoadGame()
        { 
            var now = DateTime.Now;
            foreach (var timer in timers)
            {
                this.SynchronizeTimer(timer, now);
            }
        }

        private void SynchronizeTimer(IRealtimeTimer timer, DateTime now)
        {
            var timerId = timer.Id;
            
            if (!PlayerPrefs.HasKey(timerId))
            {
                return;
            }

            var serializedTime = PlayerPrefs.GetString(timerId);
            var previousTime = DateTime.Parse(serializedTime, CultureInfo.InvariantCulture);

            var timeSpan = now - previousTime;
            var pauseSeconds = timeSpan.TotalSeconds;
            timer.Synchronize((float) pauseSeconds);
            Debug.Log($"PAUSE SECONDS {timer.Id} {pauseSeconds}");
        }

        private void SaveTimer(IRealtimeTimer timer)
        {
            Debug.Log($"SAVE TIMER {timer.Id}");

            var currentTime = DateTime.Now;
            var serializedTime = currentTime.ToString(CultureInfo.InvariantCulture);
            PlayerPrefs.SetString(timer.Id, serializedTime);
        }
        // public void Construct(IRealtimeTimer timer)
        // {
        //     _timeReward = timer;
        //     _timeReward.OnStarted += TimerStarted;
        //     LoadTime();
        // }
        //
        // private void TimerStarted(IRealtimeTimer obj)
        // {
        //     SaveTime();
        // }
        //
        // private void SaveTime()
        // {
        //     Debug.Log("Save time");
        //     PlayerPrefs.SetString(_key, DateTime.Now.ToString(CultureInfo.InvariantCulture));
        // }
        //
        // private void LoadTime()
        // {
        //     if (PlayerPrefs.HasKey(_key))
        //     {
        //         var serializedTime = PlayerPrefs.GetString(_key);
        //         var previousTime = DateTime.Parse(serializedTime, CultureInfo.InvariantCulture);
        //         var timeSpan = DateTime.Now - previousTime;
        //         var pauseSeconds = timeSpan.TotalSeconds;  
        //         Debug.Log("Pause seconds = " + pauseSeconds);
        //         _timeReward.Synchronize((float)pauseSeconds);
        //     }
        // }
    }
}