using AtomicHomework.Entities.Components;
using Entities;
using Unity.VisualScripting;
using UnityEngine;

namespace AtomicHomework.Hero.Entity
{
    public class HeroEntity : MonoEntityBase
    {
        [SerializeField] private HeroDocument _hero;
        
        private void Awake()
        {
            Add(new MoveComponent(_hero.MoveSection.OnMove));   
            Add(new RotateComponent(_hero.RotateSection.OnRotate));
            Add(new FireComponent(_hero.FireSection.OnFire));
            Add(new TakeDamageComponent(_hero.HeroLifeSection.OnTakeDamage));
            Add(new DeathComponent(_hero.HeroLifeSection.OnDeath));
        }
    }
}