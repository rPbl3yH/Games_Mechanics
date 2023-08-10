using System;
using AtomicProject.Atomic.Custom;
using AtomicProject.Atomic.Values;
using Declarative;

namespace AtomicProject.Hero
{
    [Serializable]
    public class AddBulletSection
    {
        public AtomicVariable<int> AddBulletDelay;
        public AtomicVariable<int> MaxBulletCount;
        public AtomicVariable<int> BulletCount;
        
        private float _addBulletTime;
        
        [Construct]
        public void Construct(DeclarativeModel root)
        {
            root.onFixedUpdate += deltaTime =>
            {
                if (BulletCount.Value >= MaxBulletCount.Value)
                {
                    return;
                }

                _addBulletTime += deltaTime;
                
                if (_addBulletTime >= AddBulletDelay.Value)
                {
                    BulletCount.Value++;
                    _addBulletTime = 0;
                }
            };
        }
    }
}