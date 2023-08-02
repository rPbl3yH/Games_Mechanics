using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EventBus.Game.GamePlay.Area
{
    public class AreaService
    {
        private Dictionary<Vector2Int, Character> _area = new();
        private const int Size =6;

        public AreaService()
        {
            var centerOffset = Mathf.RoundToInt(Size / 2f);
            for (int x = 0 - centerOffset; x <= Size - centerOffset; x++)
            {
                for (int y = 0 - centerOffset; y <= Size - centerOffset; y++)
                {
                    _area.Add(new Vector2Int(x, y), null);
                }
            }
        }

        public void AddCharacter(Vector2Int point, Character character)
        {
            _area[point] = character;
        }

        public Character GetCharacter(Vector3 point)
        {
            var pointInt = AreaUtils.GetVector2Int(point);
            return _area[pointInt];
        }

        public bool IsWalkable(Vector2Int point)
        {
            var result = false;
            
            if (_area.TryGetValue(point, out var value))
            {
                result = value == null;
            }

            return result;
        }
        
        public bool IsWalkable(Vector3 point)
        {
            return IsWalkable(AreaUtils.GetVector2Int(point));
        }
    }
}