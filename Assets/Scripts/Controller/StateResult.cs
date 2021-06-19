using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

class StateResult : State
{
    public StateResult(GameSystem gamesystem) : base(gamesystem) { }

    public override IEnumerator StateStart()
    {
        // Hide things from the gameing
        mGameSystem.gameBoard.gameObject.SetActive(false);
        mGameSystem.uiRoot.ShowGaming(false);

        // Show things for the result
        mGameSystem.uiRoot.ShowResult(true);
        yield return null;
    }

    public override IEnumerator StateEnd()
    {
        mGameSystem.uiRoot.ShowResult(false);
        yield return null;
    }
}
