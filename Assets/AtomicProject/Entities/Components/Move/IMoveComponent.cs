using UnityEngine;

namespace AtomicProject.Entities.Components.Move
{
    public interface IMoveComponent
    {
        public void Move(Vector3 direction);
    }
}