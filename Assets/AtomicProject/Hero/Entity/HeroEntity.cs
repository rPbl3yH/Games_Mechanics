using AtomicHomework.Entities.Components;
using Entities;
using UnityEngine;

namespace AtomicHomework.Hero.Entity
{
    public class HeroEntity : MonoEntityBase
    {
        [SerializeField] private HeroDocument _hero;
        
        private void Awake()
        {
            Add(new MoveComponent(_hero._moveSection.OnMove));   
            Add(new RotateComponent(_hero._rotateSection.OnRotate));
            Add(new FireComponent(_hero._fireSection.OnFire));
            Add(new TakeDamageComponent(_hero._lifeSection.OnTakeDamage));
        }
    }
}