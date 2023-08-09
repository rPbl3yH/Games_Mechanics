using System;
using AtomicProject.Atomic.Actions;
using AtomicProject.Atomic.Values;
using Declarative;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AtomicProject.Hero
{
    [Serializable]
    public class LifeSection
    { 
        [SerializeField]
        public AtomicVariable<int> HitPoints;
        [ShowInInspector]
        public AtomicEvent<int> OnTakeDamage = new();
        [ShowInInspector]
        public AtomicEvent OnDeath = new();
        
        [Construct]
        public void Construct()
        {
            OnTakeDamage += damage =>
            {
                if (HitPoints.Value > 0)
                {
                    HitPoints.Value -= damage;
                }
            };

            HitPoints.OnChanged += hitPoints =>
            {
                if (hitPoints <= 0)
                {
                    OnDeath?.Invoke();
                }
            };
        }
    }
}