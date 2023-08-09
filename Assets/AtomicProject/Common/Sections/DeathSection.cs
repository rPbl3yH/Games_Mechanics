using System;
using AtomicProject.Hero;
using Declarative;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AtomicProject.Enemy.Document
{
    [Serializable]
    public class DeathSection
    {
        [Construct]
        public void Construct(DeclarativeModel root, LifeSection lifeSection)
        {
            lifeSection.OnDeath += () =>
            {
                Object.Destroy(root.gameObject);
            };
        }
    }
}