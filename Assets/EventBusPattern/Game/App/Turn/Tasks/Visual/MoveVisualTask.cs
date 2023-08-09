using DG.Tweening;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class MoveVisualTask : VisualTask
    {
        private Transform _transform;
        private float _duration;
        private Vector3 _targetPoint;

        public MoveVisualTask(Transform transform, Vector3 targetPoint, float duration)
        {
            _transform = transform;
            _duration = duration;
            _targetPoint = targetPoint;
        }
        
        protected override void OnRun()
        {
            _transform.DOMove(_targetPoint, _duration).OnComplete(Finish);
        }
    }
}