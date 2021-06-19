using UnityEngine;
using UnityEngine.UI;

public class UIRoot : MonoBehaviour
{
    public GameObject objLobby;
    public GameObject objGaming;
    public GameObject objBlackTurn;
    public GameObject objWhiteTurn;
    public GameObject objResult;

    public Text textBlack;
    public Text textWhite;
    public Text textPlayerScore;
    public Text textBotScore;
    public Text textResultTitle;

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
        textPlayerScore.text = score_black.ToString();
        textBotScore.text = score_white.ToString();

        if(score_black > score_white)
        {
            textResultTitle.text = Configs.TextWinTitle;
        }
        else if (score_black == score_white)
        {
            textResultTitle.text = Configs.TextTieTitle;
        }
        else
        {
            textResultTitle.text = Configs.TextLoseTitle;
        }
    }

    public void ShowResult(bool isshow)
    {
        objResult.SetActive(isshow);
    }

    public void ReturntoLobby()
    {
        GlobalEventManager.Instance.CallAction (ActionName.GameEnterLobby);
    }
}
