using UnityEngine;

namespace AtomicProject.Entities.Components
{
    public class TransformComponent 
    {
        public Transform Transform;

        public TransformComponent(Transform transform)
        {
            Transform = transform;
        }
    }
}