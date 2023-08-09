using DG.Tweening;
using EventBusPattern.Game.App.Events;
using UnityEngine;

namespace EventBusPattern.Visual
{
    public class MoveVisualHandler : BaseHandler<MoveEvent>
    {
        protected override void OnHandleEvent(MoveEvent evt)
        {
            evt.LifeEntity.transform.DOMove(evt.TargetPoint, 0.5f);
        }
    }
}