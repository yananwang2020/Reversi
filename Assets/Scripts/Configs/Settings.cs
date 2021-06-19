using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharType
{
    Cat = 0,
    Dog = 1,
}

[Serializable]
public struct CharImage
{
    public CharType charType;
    public Sprite charImage;
}

public class Settings : MonoBehaviour
{
    public static Settings Instance;

    public CharImage[] CharImages;

    Sprite blackCharImg;
    Sprite whiteCharImg;

    private void Awake()
    {
        Instance = this;
    }

    public void ChoseCharactor(CharType char_type)
    {
        // player always move first
        // therefore, player is the black side
        // the bot is the white side
        CharType blackCharType = char_type;
        CharType whiteCharType = (CharType)(1 - (int)char_type);

        foreach (CharImage item in CharImages)
        {
            if (item.charType == char_type)
            {
                blackCharImg = item.charImage;
            }
            if (item.charType == whiteCharType)
            {
                whiteCharImg = item.charImage;
            }
        }
    }

    public Sprite GetImage(DiscSide disc_side)
    {
        if (disc_side == DiscSide.Black)
            return blackCharImg;

        if (disc_side == DiscSide.White)
            return whiteCharImg;

        return null;
    }
}
