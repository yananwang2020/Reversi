using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

class StateInit : State
{
    public StateInit(GameSystem gamesystem) : base(gamesystem) { }

    public override IEnumerator StateStart()
    {
        // Hide all UI
        mGameSystem.UIRoot.ShowLobby(false);
        mGameSystem.UIRoot.ShowGaming(false);
        mGameSystem.UIRoot.ShowResult(false);

        // Init the game board
        mGameSystem.GameBoard.InitDiscPos();
        mGameSystem.GameBoard.InitDiscs();

        // Init the game model
        mGameSystem.Modelboard.InitBoard();
        mGameSystem.Modelboard.mOnDiscInfoRefresh += mGameSystem.GameBoard.SetDiscs;
        mGameSystem.Modelboard.mOnScoreChange += mGameSystem.UIRoot.SetScores;

        // Enter lobby
        mGameSystem.SetState(new StateLobby(mGameSystem));

        yield return null;
    }

    public override IEnumerator StateEnd()
    {
        mGameSystem.UIRoot.ShowLobby(false);
        yield return null;
    }
}
