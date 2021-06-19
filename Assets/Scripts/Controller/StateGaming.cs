using System.Collections;
using UnityEngine;

class StateGaming : State
{
    public StateGaming(GameSystem gamesystem) : base(gamesystem) { }

    public override IEnumerator StateStart()
    {
        // Step 1: Init all models and UI
        mGameSystem.gameBoard.gameObject.SetActive(true);
        mGameSystem.gameBoard.InitDiscPos();
        mGameSystem.gameBoard.InitDiscs();

        mGameSystem.modelboard.InitBoard();
        mGameSystem.modelboard.mOnDiscInfoRefresh += mGameSystem.gameBoard.SetDiscs;
        mGameSystem.modelboard.mOnScoreChange += mGameSystem.uiRoot.SetScores;
        mGameSystem.gameBoard.SetDiscs(mGameSystem.modelboard.mDiscInfos);

        mGameSystem.uiRoot.ShowGaming(true);

        yield return new WaitForSeconds(1);

        // Step 2: Go to Black Turn
        mGameSystem.SetState(new StateBlackTurn(mGameSystem));
    }

    public override IEnumerator StateEnd()
    {
        yield return null;
    }
}
