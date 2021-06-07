using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRoot : MonoBehaviour
{
    public GameObject objLobby;
    
    public GameObject objGaming;
    public GameObject objBlackTurn;
    public GameObject objWhiteTurn;
    public Text textBlack;
    public Text textWhite;

    public GameObject objResult;

    public void OnDogClicked()
    {
        GlobalEventManager.Instance.CallAction(ActionName.GameStartAsDog);
    }

    public void OnCatClicked()
    {
        GlobalEventManager.Instance.CallAction(ActionName.GameStartAsCat);
    }

    public void ShowLobby(bool isshow)
    {
        objLobby.SetActive(isshow);
    }

    public void ShowGaming(bool isshow)
    {
        objGaming.SetActive(isshow);
    }

    public void BlackTurn()
    {
        objBlackTurn.SetActive(true);
        objWhiteTurn.SetActive(false);
    }

    public void WhiteTurn()
    {
        objBlackTurn.SetActive(false);
        objWhiteTurn.SetActive(true);
    }

    public void SetScores(int score_black, int score_white)
    {
        textBlack.text = score_black.ToString();
        textWhite.text = score_white.ToString();
    }

    public void ShowResult(bool isshow)
    {
        objResult.SetActive(isshow);
    }
}
