using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    public GameObject obj_lobby;
    public GameObject obj_gaming;
    public GameObject obj_result;

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
        obj_lobby.SetActive(isshow);
    }

    public void ShowGaming(bool isshow)
    {
        obj_gaming.SetActive(isshow);
    }

    public void ShowResult(bool isshow)
    {
        obj_result.SetActive(isshow);
    }
}
