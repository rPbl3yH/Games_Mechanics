using System;
using AtomicHomework.Enemy.Document;
using AtomicHomework.Hero;
using Declarative;
using UnityEngine;

namespace AtomicHomework.Atomic.Enemy.Document
{
    [Serializable]
    public class EnemyDeathSection
    {
        [Construct]
        public void Construct(EnemyDocument document, LifeSection lifeSection)
        {
            lifeSection.OnDeath += () =>
            {
                GameObject.Destroy(document.gameObject);
            };
        }
    }
}