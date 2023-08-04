﻿using System;
using AtomicProject.Atomic.Actions;
using AtomicProject.Atomic.Values;
using Declarative;
using UnityEngine;

namespace AtomicProject.Hero
{
    [Serializable]
    public class MoveSection
    {
        [SerializeField] public AtomicVariable<float> Speed;
        public AtomicEvent<Vector3> OnMove = new();
        
        private Transform _transform;
        private Vector3 _direction;
        private bool _isMoveRequired;

        [Construct]
        public void Construct(HeroDocument heroDocument)
        {
            _transform = heroDocument.Transform;
            
            OnMove += direction =>
            {
                _direction = direction;
                _isMoveRequired = true;
            };
            
            heroDocument.onFixedUpdate += deltaTime =>
            {
                if (_isMoveRequired)
                {
                    _transform.Translate(_direction * (Speed.Value * deltaTime));
                    _isMoveRequired = false;
                }   
            };
        }
    }
}