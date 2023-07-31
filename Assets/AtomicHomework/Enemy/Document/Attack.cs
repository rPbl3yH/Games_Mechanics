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
    public class Attack
    {
        public AtomicVariable<int> Damage;
        public AtomicVariable<float> TimeToAttack;
        public Timer _timer = new();

        public AtomicVariable<bool> IsCanAttack;
        public AtomicEvent<Transform> OnAttack = new();
        private Transform _target;
            
        [Construct]
        public void Construct(Follow follow)
        {
            _timer.Construct(TimeToAttack.Value);

            _timer.OnTimerFinished += () =>
            {
                IsCanAttack.Value = true;
                _timer.StopTimer();
                
                if (_target != null)
                {
                    OnAttack?.Invoke(_target);
                }
            };
            
            follow.OnTargetReach += target =>
            {
                _target = target;
                OnAttack?.Invoke(target);
            };

            follow.OnTargetLose += _ =>
            {
                _target = null;
            };

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
                            _timer.StartTimer();
                        }
                    }
                }
            };
        }
    }
}