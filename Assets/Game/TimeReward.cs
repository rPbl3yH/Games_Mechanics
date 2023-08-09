using System;
using System.Collections;
using System.Collections.Generic;
using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

public class TimeReward : MonoBehaviour
{
    [SerializeField] private int _rewardMoney = 100;
    [SerializeField] private float _timeToReceive = 5f;

    [ShowInInspector, ReadOnly]
    private Timer _timer = new();

    private void Start()
    {
        _timer.Duration = _timeToReceive;
        _timer.OnFinished += ReceiveReward;
    }

    [Button]
    public void Run()
    {
        _timer.ResetTime();
        _timer.Play();
    }
    
    private void ReceiveReward()
    {
        Debug.Log("Get reward " +_rewardMoney);
    }
}
