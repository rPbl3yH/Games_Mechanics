using UnityEngine;

namespace AtomicProject.Entities.Components.Rotate
{
    public interface IRotateComponent
    {
        void RotateInPoint(Vector3 targetPoint);
    }
}