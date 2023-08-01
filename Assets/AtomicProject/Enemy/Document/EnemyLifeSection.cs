using System;
using Atomic;
using Declarative;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace AtomicHomework.Enemy.Document
{
    [Serializable]
    public class EnemyLifeSection
    { 
        [SerializeField]
        public AtomicVariable<int> HitPoints;
        [ShowInInspector]
        public AtomicEvent<int> OnTakeDamage = new();
        [ShowInInspector]
        public AtomicEvent OnDeath = new();

        [Inject] private GameFinisher _gameFinisher;
        
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

            OnDeath += () => Debug.Log("Death enemy");
        }
    }
}