using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

class StateInit : State
{
    public StateInit(GameSystem game_system) : base(game_system) { }

    public override IEnumerator StateStart()
    {
        // Hide all UI
        myGameSystem.GameBoard.gameObject.SetActive(false);
        myGameSystem.UIRoot.ShowLobby(false);
        myGameSystem.UIRoot.ShowGaming(false);
        myGameSystem.UIRoot.ShowResult(false);

        // Init the game board
        myGameSystem.GameBoard.InitDiscPos();
        myGameSystem.GameBoard.InitDiscs();

        // Init the game model
        myGameSystem.Modelboard.InitBoard();
        myGameSystem.Modelboard.EventOnDiscInfoRefresh += myGameSystem.GameBoard.SetDiscs;
        myGameSystem.Modelboard.EventOnScoreChange += myGameSystem.UIRoot.SetScores;

        // Enter lobby
        myGameSystem.SetState(new StateLobby(myGameSystem));

        yield return null;
    }

    public override IEnumerator StateEnd()
    {
        myGameSystem.UIRoot.ShowLobby(false);
        yield return null;
    }
}
