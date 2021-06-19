using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Disc : MonoBehaviour
{
    public DiscInfo discInfo;
    public SpriteRenderer discImage;
    public Collider2D discCollider;

    public void SetInfo(DiscInfo disc_info)
    {
        discInfo = disc_info;
        discImage.sprite = Settings.Instance.GetImage(discInfo.Side);
        discImage.color = Color.white;
    }

    public void ShowAvailableColor()
    {
        discImage.sprite = Settings.Instance.GetImage(DiscSide.Black);
        Color available_color = Color.white;
        available_color.a = 0.5f;
        discImage.color = available_color;
    }
}
