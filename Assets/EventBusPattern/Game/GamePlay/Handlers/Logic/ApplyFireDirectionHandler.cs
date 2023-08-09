using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern
{
    public sealed class ApplyFireDirectionHandler : BaseHandler<ApplyFireDirectionEvent>
    {
        [Inject] private readonly LevelMap _levelMap;
        [Inject] private readonly Player _player;
    
        protected override void OnHandleEvent(ApplyFireDirectionEvent evt)
        {
            var nextPoint = evt.LifeEntity.transform.position + evt.Direction;
            var hasCharacter = false;

            for (int i = 0; i < LevelMap.Size; i++)
            {
                if (_levelMap.HasCharacter(nextPoint))
                {
                    hasCharacter = true;
                    break;
                }

                nextPoint += evt.Direction;
            }

            if (!hasCharacter)
            {
                return;
            }
            
            var target = _levelMap.GetEntity(nextPoint);
            EventBus.RaiseEvent(new DealDamageEvent(_player, target));
        }
    }
}