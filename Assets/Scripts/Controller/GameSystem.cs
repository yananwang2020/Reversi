using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameSystem : StateMachine
{
    public UIRoot ui_root;
    public ModelBoard modelboard;
    public Board board;

    private void Start()
    {
        Init();
        RegistActions();
        ShowLobby();
    }

    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
        }

        if (Input.GetKeyDown("q"))
        {
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
        }
    }

    public void Init()
    {
        modelboard = new ModelBoard();
    }

    public void RegistActions()
    {
        //GlobalEventManager.Instance.RegisterAction(ActionName.GameInit, new Action(InitGame));
        GlobalEventManager.Instance.RegisterAction(ActionName.GameStartAsCat, new Action(StartGameAsCat));
        GlobalEventManager.Instance.RegisterAction(ActionName.GameStartAsDog, new Action(StartGameAsDog));
        GlobalEventManager.Instance.RegisterAction(ActionName.GameEnd, new Action(ShowResult));
        GlobalEventManager.Instance.RegisterAction(ActionName.GamePause, new Action(ShowResult));
    }

    public void ShowLobby()
    {
        Debug.Log("ShowLobby");
        SetState(new StateLobby(this));
    }

    public void StartGameAsCat()
    {
        Debug.Log("StartGameAsCat");
        SetState(new StateGaming(this));
    }

    public void StartGameAsDog()
    {
        Debug.Log("StartGameAsDog");
        SetState(new StateGaming(this));
    }

    public void ShowResult()
    {
    }
}
