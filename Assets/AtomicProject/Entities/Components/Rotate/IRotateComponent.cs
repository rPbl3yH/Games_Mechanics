using UnityEngine;

namespace AtomicProject.Entities.Components.Rotate
{
    public interface IRotateComponent
    {
        void Rotate(Vector3 direction);
    }
}