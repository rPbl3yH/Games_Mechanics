using System;
using AtomicProject.Atomic.Actions;
using AtomicProject.Atomic.Values;
using Declarative;
using UnityEngine;

namespace AtomicProject.Hero
{
    [Serializable]
    public class RotateSection
    {
        [SerializeField] public AtomicVariable<Vector3> TargetPoint;
        [SerializeField] public AtomicEvent<Vector3> OnRotate;
        
        [Construct]
        public void Construct(HeroDocument heroDocument)
        {
            OnRotate += targetPoint =>
            {
                TargetPoint.Value = targetPoint;
            };
        }
    }
}