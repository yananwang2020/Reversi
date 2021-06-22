using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configs
{
    public static int Lines = 8;

    public static Dictionary<Vector2Int, DiscSide> InitInfo = new Dictionary<Vector2Int, DiscSide>()
        {
            { new Vector2Int(3, 3), DiscSide.White },
            { new Vector2Int(4, 4), DiscSide.White },
            { new Vector2Int(3, 4), DiscSide.Black },
            { new Vector2Int(4, 3), DiscSide.Black },
        };

    public static string TextWinTitle = "Winner winner chicken dinner!";
    public static string TextLoseTitle = "I may lose, but I will never give up!";
    public static string TextTieTitle = "Well done, you have conquered half of the board.";

    public static Color AvailablePosColor = new Color(1, 1, 1, 0.3f);

    public static float TurnIntervalSec = 0.1f;

}
