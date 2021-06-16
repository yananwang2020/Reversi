using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyExtensions
{
    public static Vector2Int Clone(this Vector2Int v)
    {
        Vector2Int new_v = new Vector2Int(v.x, v.y);
        return new_v;
    }
}