using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

class StateGaming : State
{
    public StateGaming(GameSystem gamesystem) : base(gamesystem) { }

    public override IEnumerator StateStart()
    {
        // Step 1: Init all models and UI
        mGameSystem.board.InitDiscPos();
        mGameSystem.board.InitDiscs();

        // mGameSystem.modelboard.BindOnDiscInfoChange(mGameSystem.board.SetDiscs);
        mGameSystem.modelboard.InitBoard();
        mGameSystem.modelboard.mOnDiscInfoChange += mGameSystem.board.SetDiscs;
        mGameSystem.modelboard.mOnScoreChange += mGameSystem.ui_root.SetScores;
        mGameSystem.board.SetDiscs(mGameSystem.modelboard.mDiscInfos);

        mGameSystem.ui_root.ShowGaming(true);

        yield return new WaitForSeconds(1);

        // Step 2: Go to Black Turn
        mGameSystem.SetState(new StateBlackTurn(mGameSystem));
    }

    public override IEnumerator StateEnd()
    {
        yield return null;
    }
}
