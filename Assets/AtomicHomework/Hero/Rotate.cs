using System;
using Atomic;
using Declarative;
using UnityEngine;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class Rotate
    {
        [SerializeField] public AtomicVariable<float> RotationSpeed;
        [SerializeField] public AtomicVariable<Vector3> TargetPoint;
        [SerializeField] public AtomicEvent<Vector3> OnRotate;
        
        public RotateEngine Engine = new();

        [Construct]
        public void Construct(HeroDocument heroDocument)
        {
            Engine.Construct(heroDocument.Transform, RotationSpeed, TargetPoint);
            
            OnRotate += targetPoint =>
            {
                TargetPoint.Value = targetPoint;
            };
            
            heroDocument.onUpdate += _ => Engine.Rotate();
        }
    }
}