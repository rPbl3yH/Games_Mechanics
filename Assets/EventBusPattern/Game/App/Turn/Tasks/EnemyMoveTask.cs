using EventBusPattern.Game.App.Events;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class EnemyMoveTask : Task
    {
        [Inject] private LevelMap _levelMap;
        [Inject] private EventBus _eventBus;
        
        protected override void OnRun()
        {
            var enemies = _levelMap.GetEntities<Enemy>();
            var player = _levelMap.GetEntity<Player>();
            var playerPoint = _levelMap.GetPoint(player);
            
            foreach (var enemy in enemies)
            {
                var enemyPoint = _levelMap.GetPoint(enemy);
                var movementVector = playerPoint - enemyPoint;
                if (movementVector.sqrMagnitude == 1)
                {
                    _eventBus.RaiseEvent(new DealDamageEvent(enemy, player));
                }
                else
                {
                    Vector3 direction;
                    if (Mathf.Abs(movementVector.x) > Mathf.Abs(movementVector.y))
                    {
                        direction = movementVector.x > 0 ? Vector3.right : Vector3.left;
                    }
                    else
                    {
                        direction = movementVector.y > 0 ? Vector3.forward : Vector3.back;
                    }
                    _eventBus.RaiseEvent(new ApplyMoveDirectionEvent(enemy, direction));
                }
            }
            Finish();
        }
    }
}