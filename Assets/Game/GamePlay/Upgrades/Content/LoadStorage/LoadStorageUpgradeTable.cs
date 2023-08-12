using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    [Serializable]
    public sealed class LoadStorageUpgradeTable
    {
        public int LoadStorageStep
        {
            get { return this._loadStorageStep; }
        }

        [InfoBox("Load Storage: Linear Function")] [SerializeField]
        private int _startDamage = 1;

        [SerializeField] private int _loadStorageStep = 1;

        [Space]
        [ListDrawerSettings(
            IsReadOnly = true,
            OnBeginListElementGUI = "DrawLabelForListElement"
        )]
        [SerializeField]
        private int[] _values;

        public int GetLoadStorage(int level)
        {
            var index = level - 1;
            return this._values[index];
        }

        public void OnValidate(int maxLevel)
        {
            this._values = new int[maxLevel];

            var currentDamage = this._startDamage;
            for (var i = 0; i < maxLevel; i++)
            {
                this._values[i] = currentDamage;
                currentDamage += this._loadStorageStep;
            }
        }

#if UNITY_EDITOR
        private void DrawLabelForListElement(int index)
        {
            GUILayout.Space(8);
            GUILayout.Label($"Level {index + 1}");
        }
#endif
    }
}