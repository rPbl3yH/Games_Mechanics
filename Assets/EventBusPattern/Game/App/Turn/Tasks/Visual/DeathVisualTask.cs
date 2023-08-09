using DG.Tweening;
using UnityEngine;

namespace EventBusPattern
{
    public class DeathVisualTask : VisualTask
    {
        private readonly Transform _transform;
        private readonly float _duration;

        public DeathVisualTask(Transform transform, float duration)
        {
            _transform = transform;
            _duration = duration;
        }

        protected override void OnRun()
        {
            _transform.DOScale(Vector3.zero, _duration).OnComplete(Finish);
        }

        protected override void Finish()
        {
            Object.Destroy(_transform.gameObject);
            base.Finish();
        }
    }
}