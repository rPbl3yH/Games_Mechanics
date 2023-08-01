using System;
using UnityEngine;

namespace AtomicHomework.Input
{
    public class MouseInput : MonoBehaviour
    {
        public event Action<Vector3> OnMousePointChanged;
        private Vector3 _lastPosition;
        private Plane _plane;
        private UnityEngine.Camera _camera;

        private void Start()
        {
            _camera = UnityEngine.Camera.main;
            _plane = new Plane(Vector3.up, Vector3.zero);
        }

        private void Update()
        {
            var mousePosition = UnityEngine.Input.mousePosition;
            var ray = _camera.ScreenPointToRay(mousePosition);
            var worldPoint = Vector3.zero;

            if (_plane.Raycast(ray, out float enter))
            {
                worldPoint = ray.GetPoint(enter);
            }
            
            OnMousePointChanged?.Invoke(worldPoint);
        }
    }
}
