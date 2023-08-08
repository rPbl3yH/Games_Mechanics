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

        [Construct]
        public void Construct(HeroCore heroCore)
        {
            OnEnemyFind += enemy =>
            {
                IsFind.Value = true;
                ClosetEnemyPoint.Value = enemy.Get<TransformComponent>().Transform.position;
            };
        }
    }
}