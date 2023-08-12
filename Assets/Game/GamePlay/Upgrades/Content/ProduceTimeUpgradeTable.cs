using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GamePlay.Upgrades.Content
{
    [Serializable]
    public sealed class ProduceTimeUpgradeTable
    {
        public float ProduceTimeStep
        {
            get { return this._loadStorageStep; }
        }

        [InfoBox("Unload Storage: Linear Function")] [SerializeField]
        private float _startProduceTime = 1;

        [SerializeField] private float _loadStorageStep = -0.2f;

        [Space]
        [ListDrawerSettings(
            IsReadOnly = true,
            OnBeginListElementGUI = "DrawLabelForListElement"
        )]
        [SerializeField]
        private float[] _values;

        public float GetProduceTime(int level)
        {
            var index = level - 1;
            return this._values[index];
        }

        public void OnValidate(int maxLevel)
        {
            this._values = new float[maxLevel];

            var currentDamage = this._startProduceTime;
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