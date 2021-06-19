using System;
using UnityEngine;

public class GameSystem : StateMachine
{
    public UIRoot UIRoot;
    public Board GameBoard;
    public ModelBoard Modelboard;

    private void Start()
    {
        RegistActions();
        InitGame();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                Disc disc = hit.collider.transform.GetComponentInParent<Disc>();
                if (disc != null)
                {
                    var discinfo = disc.DiscInfo;
                    StartCoroutine(mCrtState.PlaceDisc(discinfo.Pos));
                }
            }
        }
    }

    public void InitGame()
    {
        Modelboard = new ModelBoard();
        SetState(new StateInit(this));
    }

    public void RegistActions()
    {
        GlobalEventManager.Instance.RegisterAction(ActionName.GameEnterLobby, new Action(ShowLobby));
        GlobalEventManager.Instance.RegisterAction(ActionName.GameStartAsCat, new Action(StartGameAsCat));
        GlobalEventManager.Instance.RegisterAction(ActionName.GameStartAsDog, new Action(StartGameAsDog));
        GlobalEventManager.Instance.RegisterAction(ActionName.GameEnd, new Action(ShowResult));
    }

    public void ShowLobby()
    {
        Debug.Log("ShowLobby");
        SetState(new StateLobby(this));
    }

    public void StartGameAsCat()
    {
        Debug.Log("StartGameAsCat");
        Settings.Instance.ChoseCharactor(CharType.Cat);
        SetState(new StateGaming(this));
    }

    public void StartGameAsDog()
    {
        Debug.Log("StartGameAsDog");
        Settings.Instance.ChoseCharactor(CharType.Dog);
        SetState(new StateGaming(this));
    }

    [ContextMenu("ShowResult")]
    public void ShowResult()
    {
        Debug.Log("ShowResult");
        SetState(new StateResult(this));
    }
}
