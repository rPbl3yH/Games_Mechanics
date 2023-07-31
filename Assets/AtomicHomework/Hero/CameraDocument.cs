using System;
using Declarative;
using UnityEngine;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class CameraDocument : DeclarativeModel
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Transform _cameraTransform;
        
        public CameraMoveEngine CameraMoveEngine = new();
        
        [Construct]
        public void Construct()
        {
            CameraMoveEngine.Construct(_cameraTransform, _targetTransform);

            onUpdate += _ => CameraMoveEngine.Move();
        }
    }
}