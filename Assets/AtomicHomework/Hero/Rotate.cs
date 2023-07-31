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
        [SerializeField] public AtomicVariable<Vector3> Direction;
        [SerializeField] public AtomicEvent<Vector3> OnRotate;
        
        public RotateEngine Engine = new();

        [Construct]
        public void Construct(HeroDocument heroDocument)
        {
            Engine.Construct(heroDocument.Transform, RotationSpeed, Direction);
            
            OnRotate += direction =>
            {
                Direction.Value = direction;
            };
            
            heroDocument.onUpdate += _ => Engine.Rotate();
        }
    }
}