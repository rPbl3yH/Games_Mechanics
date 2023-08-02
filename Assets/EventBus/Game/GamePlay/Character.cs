using UnityEngine;

namespace EventBus.Game.GamePlay.Area
{
    public abstract class Character : MonoBehaviour
    {
        private int _life;
        
        public virtual void TakeDamage(int damage)
        {
            _life -= damage;
            print($"{name} take damage {damage}, life = {_life}");
        }
    }
}