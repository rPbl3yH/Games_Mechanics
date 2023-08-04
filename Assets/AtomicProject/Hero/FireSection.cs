using System;
using Atomic;
using AtomicHomework.Atomic.Custom;
using Declarative;
using UnityEngine;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class FireSection
    {
        public GameObject BulletPrefab;
        public Transform SpawnPoint;

        public AtomicVariable<int> BulletCount;
        public AtomicEvent OnFire = new();
        
        public AtomicVariable<float> ReloadTime;
        public AtomicVariable<bool> IsReload;

        public AtomicVariable<bool> IsCanAttack;
        public Timer _reloadTimer = new();

        [Section]
        public RefillSection RefillSection;
        
        [Construct]
        public void Construct()
        {
            _reloadTimer.Construct(ReloadTime.Value);
            
            ConstructFire();

            ConstructCooldownState();
            
            ConstructCooldownTimer();
        }

        private void ConstructCooldownTimer()
        {
            _reloadTimer.OnTimerFinished += () =>
            {
                IsReload.Value = false;
            };
        }

        private void ConstructCooldownState()
        {
            IsReload.OnChanged += isCooldown =>
            {
                if (!isCooldown)
                {
                    IsCanAttack.Value = BulletCount.Value > 0;
                }
            };
        }

        private void ConstructFire()
        {
            OnFire += () =>
            {
                if (IsReload.Value)
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