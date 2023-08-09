﻿using System;
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
        private AtomicVariable<Transform> _closetEnemy;

        [Construct]
        public void Construct(HeroDocument heroDocument)
        {
            OnEnemyFind += enemy =>
            {
                Debug.Log("Closet enemy is find");
                IsFind.Value = true;
                _closetEnemy.Value = enemy.Get<TransformComponent>().Transform;
            };

            heroDocument.onFixedUpdate += _ =>
            {
                if (_closetEnemy.Value)
                {
                    ClosetEnemyPoint.Value = _closetEnemy.Value.position;
                }
            };
        }
    }
}