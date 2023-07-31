using AtomicHomework.Hero;
using UnityEngine;
using Zenject;

namespace AtomicHomework.Input
{
    public class FireInputController : MonoBehaviour
    {
        [Inject] private HeroDocument _hero;
        
        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                _hero.Fire.OnFire?.Invoke();
            }
        }
    }
}