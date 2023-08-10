using System;
using AtomicProject.Atomic.Actions;
using AtomicProject.Atomic.Custom;
using AtomicProject.Atomic.Values;
using Declarative;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AtomicProject.Hero
{
    [Serializable]
    public class FireSection
    {
        public Transform Parent;
        public GameObject BulletPrefab;
        public Transform FirePoint;

        public AtomicAction FireRequest = new();
        public AtomicAction FireAction = new();

        public AtomicVariable<bool> IsFire;

        public AtomicVariable<float> ReloadTime;
        public Timer _reloadTimer = new();

        [Section]
        public AddBulletSection _addBulletSection;
        
        [Construct]
        public void Construct(DeclarativeModel root, AddBulletSection addBulletSection)
        {
            _reloadTimer.Construct(ReloadTime.Value);
            
            FireRequest.Use(() =>
            {
                if (_reloadTimer.IsPlaying)
                {
                    IsFire.Value = false;
                    return;
                }

                if (addBulletSection.BulletCount.Value <= 0)
                {
                    IsFire.Value = false;
                    return;
                }

                IsFire.Value = true;
                FireAction?.Invoke();
            });

            FireAction.Use(() =>
            {
                Object.Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation, Parent);
                addBulletSection.BulletCount.Value--;
                _reloadTimer.StartTimer();
            });
        }
    }
}