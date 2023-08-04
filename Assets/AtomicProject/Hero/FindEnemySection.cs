using System;
using AtomicProject.Atomic.Actions;
using AtomicProject.Atomic.Values;
using AtomicProject.Entities.Components;
using Declarative;
using Entities;

namespace AtomicProject.Hero
{
    [Serializable]
    public class FindEnemySection
    {
        public AtomicEvent<IEntity> OnEnemyFind = new();
        public AtomicVariable<bool> IsFind;

        private IEntity _closetEnemy;

        [Construct]
        public void Construct(HeroCore heroCore)
        {
            OnEnemyFind += enemy =>
            {
                IsFind.Value = true;
                _closetEnemy = enemy;
            };

            heroCore.MoveSection.OnMoveFinished += () =>
            {
                if (IsFind.Value)
                {
                    heroCore.RotateSection.TargetPoint.Value =
                        _closetEnemy.Get<TransformComponent>().Transform.position;
                    heroCore.FireSection.OnFire?.Invoke();
                }
            };
        }
    }
}