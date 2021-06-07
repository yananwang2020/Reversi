using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Disc : MonoBehaviour
{
    public DiscInfo discInfo;
    public SpriteRenderer discImage;
    public Collider2D discCollider;

    Dictionary<DiscValue, Color> mDiscColors;

    private void Awake()
    {
        mDiscColors = new Dictionary<DiscValue, Color>()
        {
            { DiscValue.None, new Color(0, 0, 0, 0) },
            { DiscValue.Black, Color.black },
            { DiscValue.White, Color.white }
        };
    }

    public void SetInfo(DiscInfo disc_info)
    {
        discInfo = disc_info;
        discImage.color = mDiscColors[discInfo.V];
    }
}
