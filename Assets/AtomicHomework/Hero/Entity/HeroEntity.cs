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
            Add(new MoveComponent(_hero.Move.OnMove));   
            Add(new RotateComponent(_hero.Rotate.OnRotate));
            Add(new FireComponent(_hero.Fire.OnFire));
            Add(new TakeDamageComponent(_hero.Life.OnTakeDamage));
        }
    }
}