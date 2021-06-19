using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Disc : MonoBehaviour
{
    public DiscInfo DiscInfo;
    public SpriteRenderer DiscImage;
    public Collider2D DiscCollider;

    public void SetInfo(DiscInfo disc_info)
    {
        DiscInfo = disc_info;
        DiscImage.sprite = Settings.Instance.GetImage(DiscInfo.Side);
        DiscImage.color = Color.white;
    }

    public void ShowAvailableColor()
    {
        DiscImage.sprite = Settings.Instance.GetImage(DiscSide.Black);
        Color available_color = Color.white;
        available_color.a = 0.5f;
        DiscImage.color = available_color;
    }
}
