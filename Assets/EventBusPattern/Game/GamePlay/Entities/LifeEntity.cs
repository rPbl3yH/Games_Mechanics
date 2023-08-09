using EventBusPattern.Game.App.Events;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public abstract class LifeEntity : MonoBehaviour
    {
        public int Life = 3;
        public int Damage = 1;
    }
}