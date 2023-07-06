using System;
using UnityEngine;

namespace Homeworks.SaveLoad
{
    [Serializable]
    public sealed class UnitObject : MonoBehaviour
    {
        [SerializeField]
        public int hitPoints;

        [SerializeField]
        public int speed;

        [SerializeField]
        public int damage;
    }
}