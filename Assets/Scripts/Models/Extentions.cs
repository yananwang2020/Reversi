using Reversi.Models;
using UnityEngine;


namespace Reversi.Models
{
    public static class MyExtensions
    {
        public static DiscInfo GetItem(this DiscInfo[,] dict, Vector2Int index)
        {
            return dict[index.x, index.y];
        }
    }
}