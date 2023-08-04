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
            Add(new MoveComponent(_hero.MoveSection.OnMove));   
            Add(new RotateComponent(_hero.RotateSection.OnRotate));
            Add(new FireComponent(_hero.FireSection.OnFire));
            Add(new TakeDamageComponent(_hero._lifeSection.OnTakeDamage));
            Add(new DeathComponent(_hero._lifeSection.OnDeath));
        }
    }
}