using UnityEngine;

public static class Substitution
{
    public static T CreateComponent<T>() where T : Component
    {
        return new GameObject().AddComponent<T>();
    }
}