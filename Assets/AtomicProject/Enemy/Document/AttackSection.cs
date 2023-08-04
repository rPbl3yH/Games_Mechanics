using System;
using Atomic;
using AtomicHomework.Atomic.Custom;
using AtomicHomework.Entities.Components;
using Declarative;
using Entities;
using UnityEngine;

namespace AtomicProject.Enemy.Document
{
    [Serializable]
    public class AttackSection
    {
        public AtomicVariable<int> Damage;
        public AtomicVariable<float> TimeToAttack;
        public Timer _reloadTimer = new();

        public AtomicEvent<Transform> OnAttack = new();
        private Transform _target;
            
        [Construct]
        public void Construct(EnemyDocument enemyDocument, FollowSection followSection)
        {
            _reloadTimer.Construct(TimeToAttack.Value);

            ConstructTargetReach(followSection);
            ConstructTargetLose(followSection);
            ConstructAttack();
            ConstructCheckTarget(enemyDocument);
        }

        private void ConstructCheckTarget(EnemyDocument enemyDocument)
        {
            enemyDocument.onFixedUpdate += _ =>
            {
                if (_reloadTimer.IsEnabled)
                {
                    return;
                }

                if (_target == null)
                {
                    return;
                }

                OnAttack?.Invoke(_target);
            };
        }

        private void ConstructAttack()
        {
            OnAttack += target =>
            {
                if (!target.TryGetComponent(out IEntity entity))
                {
                    return;
                }
                
                if (!entity.TryGet(out ITakeDamageComponent takeDamageComponent))
                {
                    return;
                }

                takeDamageComponent.TakeDamage(Damage.Value);
                _reloadTimer.StartTimer();
            };
        }

        private void ConstructTargetLose(FollowSection followSection)
        {
            followSection.FollowMechanics.OnTargetLose += _ => _target = null;
        }

        private void ConstructTargetReach(FollowSection followSection)
        {
            followSection.FollowMechanics.OnTargetReach += target => _target = target;
        }
    }
}