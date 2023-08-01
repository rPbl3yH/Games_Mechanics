using System;
using AtomicHomework.Enemy.Document;
using AtomicHomework.Hero;
using Declarative;
using UnityEngine;

namespace AtomicHomework.Atomic.Enemy.Document
{
    [Serializable]
    public class DeathSection
    {
        [Construct]
        public void Construct(EnemyDocument document, EnemyLifeSection lifeSection)
        {
            lifeSection.OnDeath += () =>
            {
                GameObject.Destroy(document.gameObject);
            };
        }
    }
}