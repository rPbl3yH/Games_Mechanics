using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
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

        public float GetCurrentProgress()
        {
            return _timer.Progress;
        }

        public void SetTimeProgress(float progress)
        {
            _timer.Progress = progress;
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
}
