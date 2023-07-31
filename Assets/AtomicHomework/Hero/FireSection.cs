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

        public AtomicVariable<bool> IsCanAttack;
        public TimerMechanics TimerMechanics;

        [Section]
        public FireCooldown FireCooldown;
        
        
        [Construct]
        public void Construct()
        {
            TimerMechanics.Construct(Delay.Value);

            OnFire += () =>
            {
                if (IsCanAttack.Value)
                {
                    GameObject.Instantiate(BulletPrefab, SpawnPoint.position, SpawnPoint.rotation);
                    BulletCount.Value--;
                    TimerMechanics.StartTimer();
                }
            };

            TimerMechanics.OnTimerFinished += () =>
            {
                BulletCount.Value++;
                
                if (BulletCount.Value == 5)
                {
                    TimerMechanics.StopTimer();
                }
            };

            BulletCount.OnChanged += count =>
            {
                if (count > 0)
                {
                    IsCanAttack.Value = !FireCooldown.IsCooldown.Value;
                }
                else
                {
                    IsCanAttack.Value = false;
                }
            };

            FireCooldown.IsCooldown.OnChanged += isCooldown =>
            {
                if (!isCooldown)
                {
                    IsCanAttack.Value = BulletCount.Value > 0;
                }
            };
        }
    }
    
    [Serializable]
    public class FireCooldown
    {
        public AtomicVariable<float> CoolDown;
        public TimerMechanics TimerMechanics;

        public AtomicVariable<bool> IsCooldown;

        [Construct]
        public void Construct(FireSection fireSection)
        {
            TimerMechanics.Construct(CoolDown.Value);
                
            fireSection.OnFire += () =>
            {
                if (!IsCooldown.Value)  
                {
                    IsCooldown.Value = true;
                    TimerMechanics.StartTimer();
                }
            };

            TimerMechanics.OnTimerFinished += () =>
            {
                IsCooldown.Value = false;
                TimerMechanics.StopTimer();
            };
        }
    }
}