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
        
        public AtomicAction<Transform> FollowRequest = new();
        public FollowMechanics FollowMechanics = new();
        private AtomicVariable<Transform> _target = new();
        private AtomicVariable<bool> _isMoveRequired = new ();
        
        [Construct]
        public void Construct(DeclarativeModel declarativeModel)
        {
            FollowRequest.Use(target => 
            {
                _target.Value = target;
                _isMoveRequired.Value = true;
            });
            
            FollowMechanics.Construct(_isMoveRequired, declarativeModel.transform, _target, Speed, MinDistance);
        }
    }
}