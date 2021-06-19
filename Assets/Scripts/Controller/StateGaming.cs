using System.Collections;
using UnityEngine;

class StateGaming : State
{
    public StateGaming(GameSystem gamesystem) : base(gamesystem) { }

    public override IEnumerator StateStart()
    {
        mGameSystem.Modelboard.SetGameStartDiscs();
        mGameSystem.GameBoard.gameObject.SetActive(true);
        mGameSystem.UIRoot.ShowGaming(true);

        yield return new WaitForSeconds(1);

        // Step 2: Go to Black Turn
        mGameSystem.SetState(new StateBlackTurn(mGameSystem));
    }

    public override IEnumerator StateEnd()
    {
        yield return null;
    }
}
