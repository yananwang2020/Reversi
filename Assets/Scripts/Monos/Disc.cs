using UnityEngine;
using UnityEngine.UI;

public class Disc : MonoBehaviour
{
    public DiscInfo DiscInfo;
    Image selfImage;

    public void Awake()
    {
        selfImage = this.gameObject.GetComponent<Image>();
    }

    public void SetInfo(DiscInfo disc_info)
    {
        DiscInfo = disc_info;
        Sprite disc_sprite = CharSettings.Instance.GetImage(DiscInfo.Side);
        selfImage.sprite = disc_sprite;
        if (disc_sprite != null)
        {
            selfImage.color = Color.white;
        }
        else
        {
            selfImage.color = Color.clear;
        }
    }

    public void ShowAvailableColor()
    {
        selfImage.sprite = CharSettings.Instance.GetImage(DiscSide.Black);
        selfImage.color = Configs.AvailablePosColor;
    }
}
