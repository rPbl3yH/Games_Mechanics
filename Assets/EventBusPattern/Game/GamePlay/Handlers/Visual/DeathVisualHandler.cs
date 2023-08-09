using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern.Visual
{
    public class DeathVisualHandler : BaseHandler<DeathEvent>
    {
        [Inject] private VisualTaskPipeline _visualTaskPipeline;
        
        protected override void OnHandleEvent(DeathEvent evt)
        {
            _visualTaskPipeline.AddTask(new DeathVisualTask(evt.LifeEntity.transform, 0.3f));
        }
    }
}