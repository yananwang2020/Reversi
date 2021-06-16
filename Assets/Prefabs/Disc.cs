using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Disc : MonoBehaviour
{
    public DiscInfo discInfo;
    public SpriteRenderer discImage;
    public Collider2D discCollider;

    Dictionary<DiscSide, Color> mDiscColors;

    private void Awake()
    {
        mDiscColors = new Dictionary<DiscSide, Color>()
        {
            { DiscSide.None, new Color(0, 0, 0, 0) },
            { DiscSide.Black, Color.black },
            { DiscSide.White, Color.white }
        };
    }

    public void SetInfo(DiscInfo disc_info)
    {
        discInfo = disc_info;
        discImage.color = mDiscColors[discInfo.Side];
    }

    public void ShowAvailableColor()
    {
        Color available_color = mDiscColors[DiscSide.Black];
        available_color.a = 0.5f;
        discImage.color = available_color;
    }
}
