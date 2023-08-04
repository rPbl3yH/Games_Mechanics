using System;
using AtomicProject.Hero;
using Declarative;
using UnityEngine;

namespace AtomicProject.Enemy.Document
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