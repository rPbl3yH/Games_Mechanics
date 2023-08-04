using AtomicProject.Atomic.Actions;
using UnityEngine;

namespace AtomicProject.Entities.Components.Follow
{
    public class FollowComponent : IFollowComponent
    {
        private readonly IAtomicAction<Transform> _onFollow;

        public FollowComponent(IAtomicAction<Transform> onFollow)
        {
            _onFollow = onFollow;
        }

        public void Follow(Transform transform)
        {
            _onFollow?.Invoke(transform);
        }
    }
}