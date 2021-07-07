using Reversi.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Reversi.Monos
{
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

        public Image imgBlack;
        public Image imgWhite;

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
            imgBlack.sprite = CharSettings.Instance.GetImage(DiscSide.Black);
            imgWhite.sprite = CharSettings.Instance.GetImage(DiscSide.White);
            objBlackTurn.SetActive(false);
            objWhiteTurn.SetActive(false);

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

            if (score_black > score_white)
            {
                textResultTitle.text = GlobalConfigs.TextWinTitle;
            }
            else if (score_black == score_white)
            {
                textResultTitle.text = GlobalConfigs.TextTieTitle;
            }
            else
            {
                textResultTitle.text = GlobalConfigs.TextLoseTitle;
            }
        }

        public void ShowResult(bool isshow)
        {
            objResult.SetActive(isshow);
        }

        public void ReturntoLobby()
        {
            GlobalEventManager.Instance.CallAction(ActionName.GameEnterLobby);
        }
    }
}