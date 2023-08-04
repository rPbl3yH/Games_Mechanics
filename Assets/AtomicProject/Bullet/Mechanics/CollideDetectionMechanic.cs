using System;
using Entities;
using UnityEngine;

namespace AtomicProject.Bullet.Mechanics
{
    public class CollideDetectionMechanic : MonoBehaviour
    {
        public event Action<IEntity> OnTriggerEntered;
            
        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody.TryGetComponent(out IEntity entity))
            {
                OnTriggerEntered?.Invoke(entity);
            }
        }
    }
}