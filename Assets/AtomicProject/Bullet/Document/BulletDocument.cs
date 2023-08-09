using AtomicProject.Atomic.Values;
using AtomicProject.Bullet.Mechanics;
using AtomicProject.Entities.Components.Damage;
using Declarative;
using UnityEngine;

namespace AtomicProject.Bullet.Document
{
    public class BulletDocument : DeclarativeModel
    {
        public Transform Transform;
        public AtomicVariable<float> Speed;

        public TriggerDetection _triggerDetection;

        public AtomicVariable<int> Damage;

        [Construct]
        public void Construct()
        {
            onUpdate += deltaTime =>
            {
                Transform.Translate(Vector3.forward * (Speed.Value * deltaTime));
            };

            _triggerDetection.OnTriggerEntered += entity =>
            {
                if (entity.TryGet(out ITakeDamageComponent component))
                {
                    component.TakeDamage(Damage.Value);
                    Destroy(gameObject);
                }
            };
        }
    }
}