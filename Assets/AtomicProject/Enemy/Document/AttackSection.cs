using System;
using AtomicProject.Atomic.Actions;
using AtomicProject.Atomic.Custom;
using AtomicProject.Atomic.Values;
using AtomicProject.Entities.Components.Damage;
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
        public void Construct(DeclarativeModel root, FollowSection followSection)
        {
            _reloadTimer.Construct(TimeToAttack.Value);

            followSection.FollowMechanics.OnTargetLose += _ => _target = null;
            followSection.FollowMechanics.OnTargetReach += target => _target = target;
            
            ConstructAttack();
            ConstructCheckTarget(root);
        }

        private void ConstructCheckTarget(DeclarativeModel root)
        {
            root.onFixedUpdate += _ =>
            {
                if (_reloadTimer.IsPlaying)
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
    }
}