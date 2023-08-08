using System.Collections.Generic;
using EventBusPattern.Game.GamePlay;
using UnityEngine;
using Zenject;

namespace EventBus.Game.GamePlay.Area
{
    public class LevelMap
    {
        private readonly Dictionary<Vector2Int, LifeEntity> _map = new();
        public const int Size = 6;

        public LevelMap()
        {
            var centerOffset = Mathf.RoundToInt(Size / 2f);
            for (int x = 0 - centerOffset; x <= Size - centerOffset; x++)
            {
                for (int y = 0 - centerOffset; y <= Size - centerOffset; y++)
                {
                    _map.Add(new Vector2Int(x, y), null);
                }
            }
        }

        public void AddEntity(Vector2Int point, LifeEntity lifeEntity)
        {
            _map[point] = lifeEntity;
        }
        
        public void AddEntity(Vector3 point, LifeEntity lifeEntity)
        {
            var pointInt = LevelMapUtils.GetVector2Int(point);
            AddEntity(pointInt, lifeEntity);
        }

        public bool HasCharacter(Vector3 point)
        {
            var pointInt = LevelMapUtils.GetVector2Int(point);
            return HasCharacter(pointInt);
        }

        public bool HasCharacter(Vector2Int pointInt)
        {
            if (_map.TryGetValue(pointInt, out var character))
            {
                return character != null;
            }

            return false;
        }
        
        public LifeEntity GetCharacter(Vector3 point)
        {
            var pointInt = LevelMapUtils.GetVector2Int(point);
            return _map[pointInt];
        }

        public bool IsWalkable(Vector2Int point)
        {
            if (!_map.ContainsKey(point))
            {
                return false;
            }
            
            return !HasCharacter(point);
        }
        
        public bool IsWalkable(Vector3 point)
        {
            return IsWalkable(LevelMapUtils.GetVector2Int(point));
        }
    }
}