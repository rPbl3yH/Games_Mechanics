using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    [Serializable]
    public sealed class UpgradePriceTable
    {
        [Space]
        [SerializeField]
        private int basePrice;

        [Space]
        [ListDrawerSettings(OnBeginListElementGUI = "DrawLevels")]
        [SerializeField]
        private int[] levels;

        public int GetPrice(int level)
        {
            var index = level - 1;
            index = Mathf.Clamp(index, 0, levels.Length - 1);
            return levels[index];
        }

        private void DrawLevels(int index)
        {
            GUILayout.Space(8);
            GUILayout.Label($"Level #{index + 1}");
        }
        
        public void OnValidate(int maxLevel)
        {
            EvaluatePriceTable(maxLevel);
        }

        private void EvaluatePriceTable(int maxLevel)
        {
            var table = new int[maxLevel];
            table[0] = new int();
            for (var level = 2; level <= maxLevel; level++)
            {
                var price = basePrice * level;
                table[level - 1] = price;
            }

            levels = table;
        }
    }
}