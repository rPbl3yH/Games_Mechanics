using System;
using AtomicProject.Atomic.Actions;
using AtomicProject.Atomic.Custom;
using AtomicProject.Atomic.Values;
using Declarative;
using UnityEngine;

namespace AtomicProject.Enemy.Document
{
    [Serializable]
    public class FollowSection
    {
        public AtomicVariable<float> Speed;
        public AtomicVariable<float> MinDistance;
        
        public AtomicEvent<Transform> OnFollow = new();
        public FollowMechanics FollowMechanics = new();
        private AtomicVariable<Transform> _target = new();
        private AtomicVariable<bool> _isMoveRequired = new ();
        
        [Construct]
        public void Construct(EnemyDocument enemyDocument)
        {
            FollowMechanics.Construct(_isMoveRequired, enemyDocument.Transform, _target, Speed, MinDistance);
            
            OnFollow += target =>
            {
                _target.Value = target;
                _isMoveRequired.Value = true;
            };
        }
    }
}