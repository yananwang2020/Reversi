using UnityEngine;

public class Disc : MonoBehaviour
{
    public DiscInfo DiscInfo;
    public SpriteRenderer DiscImage;
    public Collider2D DiscCollider;

    public void SetInfo(DiscInfo disc_info)
    {
        DiscInfo = disc_info;
        DiscImage.sprite = CharSettings.Instance.GetImage(DiscInfo.Side);
        DiscImage.color = Color.white;
    }

    public void ShowAvailableColor()
    {
        DiscImage.sprite = CharSettings.Instance.GetImage(DiscSide.Black);
        DiscImage.color = Configs.AvailablePosColor;
    }
}
