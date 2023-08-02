using UnityEngine;

public sealed class LevelMapUtils
{
    public static Vector2Int GetVector2Int(Vector3 point)
    {
        return new Vector2Int(Mathf.RoundToInt(point.x), Mathf.RoundToInt(point.z));
    }
}