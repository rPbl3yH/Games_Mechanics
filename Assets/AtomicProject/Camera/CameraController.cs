﻿using UnityEngine;

namespace AtomicProject.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Transform _cameraTransform;
        
        private void Update()
        {
            _cameraTransform.position = _targetTransform.position;
        }
    }
}