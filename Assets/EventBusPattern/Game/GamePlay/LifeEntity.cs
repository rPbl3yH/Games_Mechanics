using UnityEngine;

namespace EventBusPattern.Game.GamePlay
{
    public abstract class LifeEntity : MonoBehaviour
    {
        private int _life = 3;
        private int _damage = 1;

        public int GetDamage()
        {
            return _damage;
        }
        
        public virtual void TakeDamage(int damage)
        {
            _life -= damage;
            print($"{name} take damage {damage}, life = {_life}");
            
            if (_life <= 0)
            {
                Death();
            }
        }

        public virtual void Death()
        {
            Destroy(gameObject);
        }
    }
}