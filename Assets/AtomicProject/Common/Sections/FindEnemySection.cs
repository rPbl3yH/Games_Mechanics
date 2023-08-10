using System;
using AtomicProject.Atomic.Actions;
using AtomicProject.Atomic.Values;
using AtomicProject.Entities.Components;
using Declarative;
using Entities;
using UnityEngine;

namespace AtomicProject.Hero
{
    [Serializable]
    public class FindEnemySection
    {
        public AtomicEvent<IEntity> OnEnemyFind = new();
        public AtomicVariable<bool> IsFind;
        public AtomicVariable<Vector3> ClosetEnemyPoint;
        private AtomicVariable<Transform> _closetEnemy = new();

        [Construct]
        public void Construct(DeclarativeModel root)
        {
            OnEnemyFind += enemy =>
            {
                IsFind.Value = true;
                _closetEnemy.Value = enemy.Get<TransformComponent>().Transform;
            };

            root.onFixedUpdate += _ =>
            {
                if (_closetEnemy.Value == null)
                {
                    IsFind.Value = false;
                    return;
                }

                ClosetEnemyPoint.Value = _closetEnemy.Value.position;
            };
        }
    }
}