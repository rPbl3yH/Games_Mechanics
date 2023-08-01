using System;
using Atomic;
using AtomicHomework.Atomic.Custom;
using AtomicHomework.Entities.Components;
using Declarative;
using Entities;
using UnityEngine;

namespace AtomicHomework.Enemy.Document
{
    [Serializable]
    public class AttackSection
    {
        public AtomicVariable<int> Damage;
        public AtomicVariable<float> TimeToAttack;
        public Timer _cooldownTimer = new();

        public AtomicVariable<bool> IsCanAttack;
        public AtomicEvent<Transform> OnAttack = new();
        private Transform _target;
            
        [Construct]
        public void Construct(FollowSection followSection)
        {
            _cooldownTimer.Construct(TimeToAttack.Value);

            ConstructCooldownTimer();
            
            ConstructTargetReach(followSection);

            ConstructTargetLose(followSection);

            ConstructAttack();
        }

        private void ConstructAttack()
        {
            OnAttack += target =>
            {
                if (IsCanAttack.Value)
                {
                    if (target.TryGetComponent(out IEntity entity))
                    {
                        if (entity.TryGet(out ITakeDamageComponent takeDamageComponent))
                        {
                            takeDamageComponent.TakeDamage(Damage.Value);
                            IsCanAttack.Value = false;
                            _cooldownTimer.StartTimer();
                        }
                    }
                }
            };
        }

        private void ConstructTargetLose(FollowSection followSection)
        {
            followSection.OnTargetLose += _ => { _target = null; };
        }

        private void ConstructTargetReach(FollowSection followSection)
        {
            followSection.OnTargetReach += target =>
            {
                _target = target;
                OnAttack?.Invoke(target);
            };
        }

        private void ConstructCooldownTimer()
        {
            _cooldownTimer.OnTimerFinished += () =>
            {
                IsCanAttack.Value = true;
                _cooldownTimer.StopTimer();

                if (_target != null)
                {
                    OnAttack?.Invoke(_target);
                }
            };
        }
    }
}