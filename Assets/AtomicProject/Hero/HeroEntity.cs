using AtomicProject.Entities.Components;
using AtomicProject.Entities.Components.Damage;
using AtomicProject.Entities.Components.Death;
using AtomicProject.Entities.Components.Fire;
using AtomicProject.Entities.Components.Move;
using AtomicProject.Entities.Components.Rotate;
using Entities;
using UnityEngine;

namespace AtomicProject.Hero.Entity
{
    public class HeroEntity : MonoEntityBase
    {
        [SerializeField] private HeroDocument _hero;
        
        private void Awake()
        {
            Add(new MoveComponent(_hero.Core.MoveSection.MoveRequest));   
            Add(new RotateComponent(_hero.Core.RotateSection.OnRotate));
            Add(new FireComponent(_hero.Core.FireSection.FireRequest));
            Add(new TakeDamageComponent(_hero.Core.LifeSection.OnTakeDamage));
            Add(new DeathComponent(_hero.Core.LifeSection.OnDeath));
            Add(new FindComponent(_hero.Core.FindEnemySection.OnEnemyFind));
            Add(new TransformComponent(_hero.Transform));
        }
    }
}