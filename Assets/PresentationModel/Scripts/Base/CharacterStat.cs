using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterStat
    {

        public event Action<int> OnValueChanged; 

        [ShowInInspector, ReadOnly]
        public string Name { get; private set; }

        [ShowInInspector, ReadOnly]
        public int Value { get; private set; }
        
        public CharacterStat(string name, int value) {
            Name = name;
            Value = value;
        }

        [Button]
        public void ChangeName(string name) {
            Name = name;
        }

        [Button]
        public void ChangeValue(int value)
        {
            this.Value = value;
            this.OnValueChanged?.Invoke(value);
        }
    }
}