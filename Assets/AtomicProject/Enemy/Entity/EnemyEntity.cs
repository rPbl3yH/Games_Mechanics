﻿using AtomicHomework.Entities.Components;
using AtomicProject.Enemy.Document;
using AtomicProject.Entities.Components;
using Entities;
using UnityEngine;

namespace AtomicProject.Enemy.Entity
{
    public class EnemyEntity : MonoEntityBase
    {
        [SerializeField] private EnemyDocument _enemyDocument;
        
        private void Awake()
        {
            Add(new TakeBulletDamageComponent(_enemyDocument.LifeSection.OnTakeDamage));
            Add(new FollowComponent(_enemyDocument.FollowSection.OnFollow));
            Add(new TransformComponent(_enemyDocument.transform));
        }
    }
}