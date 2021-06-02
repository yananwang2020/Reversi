using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Disc : MonoBehaviour
{
    DiscValue disc_value;
    public SpriteRenderer disc_image;

    Dictionary<DiscValue, Color> disc_colors;

    private void Awake()
    {
        disc_colors = new Dictionary<DiscValue, Color>()
        {
            { DiscValue.None, new Color(0, 0, 0, 0) },
            { DiscValue.Black, Color.black },
            { DiscValue.White, Color.white }
        };
    }

    public void SetValue(DiscValue newvalue)
    {
        Debug.Log("Disc set value");
        disc_value = newvalue;
        disc_image.color = disc_colors[disc_value];
    }
}
