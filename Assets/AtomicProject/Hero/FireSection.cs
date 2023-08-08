using System;
using AtomicProject.Atomic.Actions;
using AtomicProject.Atomic.Custom;
using AtomicProject.Atomic.Values;
using Declarative;
using UnityEngine;

namespace AtomicProject.Hero
{
    [Serializable]
    public class FireSection
    {
        public GameObject BulletPrefab;
        public Transform SpawnPoint;

        public AtomicVariable<int> BulletCount;
        public AtomicEvent OnFire = new();
        
        public AtomicVariable<float> ReloadTime;
        public Timer _reloadTimer = new();

        [Section]
        public RefillSection RefillSection;
        
        [Construct]
        public void Construct()
        {
            _reloadTimer.Construct(ReloadTime.Value);
            ConstructFire();
        }
        
        private void ConstructFire()
        {
            OnFire += () =>
            {
                if (_reloadTimer.IsPlaying)
                {
                    return;
                }

                if (BulletCount.Value <= 0)
                {
                    return;
                }
                
                GameObject.Instantiate(BulletPrefab, SpawnPoint.position, SpawnPoint.rotation);
                BulletCount.Value--;
                _reloadTimer.StartTimer();
            };
        }
    }
}