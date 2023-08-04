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
        
        private bool _isRotateRequired;

        [Construct]
        public void Construct(HeroDocument heroDocument)
        {
            heroDocument.onFixedUpdate += _ =>
            {
                if (_isRotateRequired)
                {
                    var direction = TargetPoint.Value - heroDocument.transform.position;
                    heroDocument.transform.rotation = Quaternion.LookRotation(direction);
                    _isRotateRequired = false;
                }
            };
            
            OnRotate += targetPoint =>
            {
                TargetPoint.Value = targetPoint;
                _isRotateRequired = true;
            };
        }
    }
}