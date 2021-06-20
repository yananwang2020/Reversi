using UnityEngine;

public static class MyExtensions
{
    public static DiscInfo GetItem(this DiscInfo[,] dict, Vector2Int index)
    {
        return dict[index.x, index.y];
    }
}