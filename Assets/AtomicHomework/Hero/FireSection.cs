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
        public AtomicVariable<int> Delay;

        public AtomicVariable<int> BulletCount;
        public AtomicEvent OnFire = new();
        
        public AtomicVariable<float> Cooldown;
        public AtomicVariable<bool> IsCooldown;

        public AtomicVariable<bool> IsCanAttack;
        public Timer _bulletRefillTimer = new();
        public Timer _cooldownTimer = new();
        
        [Construct]
        public void Construct()
        {
            _bulletRefillTimer.Construct(Delay.Value);
            _cooldownTimer.Construct(Cooldown.Value);
            
            _bulletRefillTimer.StartTimer();
            
            OnFire += () =>
            {
                if (IsCanAttack.Value)
                {
                    GameObject.Instantiate(BulletPrefab, SpawnPoint.position, SpawnPoint.rotation);
                    BulletCount.Value--;
                    _bulletRefillTimer.StartTimer();
                }
                
                if (!IsCooldown.Value)  
                {
                    IsCooldown.Value = true;
                    _cooldownTimer.StartTimer();
                }
            };

            _bulletRefillTimer.OnTimerFinished += () =>
            {
                BulletCount.Value++;
                
                if (BulletCount.Value == 5)
                {
                    _bulletRefillTimer.StopTimer();
                }
            };

            BulletCount.OnChanged += count =>
            {
                if (count > 0)
                {
                    IsCanAttack.Value = !IsCooldown.Value;
                }
                else
                {
                    IsCanAttack.Value = false;
                }
            };

            IsCooldown.OnChanged += isCooldown =>
            {
                if (!isCooldown)
                {
                    IsCanAttack.Value = BulletCount.Value > 0;
                }
            };
            
            _cooldownTimer.OnTimerFinished += () =>
            {
                IsCooldown.Value = false;
                _cooldownTimer.StopTimer();
            };
        }
    }
}