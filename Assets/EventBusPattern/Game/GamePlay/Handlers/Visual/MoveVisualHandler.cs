using DG.Tweening;
using EventBusPattern.Game.App.Events;
using UnityEngine;
using Zenject;

namespace EventBusPattern.Visual
{
    public class MoveVisualHandler : BaseHandler<MoveEvent>
    {
        [Inject] private VisualTaskPipeline _visualTaskPipeline;
        
        protected override void OnHandleEvent(MoveEvent evt)
        {
            _visualTaskPipeline.AddTask(new MoveVisualTask(evt.LifeEntity.transform, evt.TargetPoint, evt.Duration));
        }
    }
}