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
        public AtomicVariable<Vector3> LookPoint;
        public AtomicEvent<Vector3> OnRotate;
        
        [Construct]
        public void Construct()
        {
            OnRotate += lookPoint =>
            {
                LookPoint.Value = lookPoint;
            };
        }
    }
}