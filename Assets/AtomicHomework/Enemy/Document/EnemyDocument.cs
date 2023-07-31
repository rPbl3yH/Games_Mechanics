﻿using AtomicHomework.Atomic.Enemy.Document;
using AtomicHomework.Hero;
using Declarative;
using UnityEngine;

namespace AtomicHomework.Enemy.Document
{
    public class EnemyDocument : DeclarativeModel
    {
        public Transform Transform;
        
        [Section] 
        public LifeSection _lifeSection;

        [Section]
        public Death Death;

        [Section]
        public Follow Follow;

        [Section]
        public Attack Attack;
    }
    
}