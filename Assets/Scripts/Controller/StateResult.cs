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
        yield return new WaitForSeconds(3);
        // Hide things from the gameing
        mGameSystem.GameBoard.gameObject.SetActive(false);
        mGameSystem.UIRoot.ShowGaming(false);

        // Show things for the result
        mGameSystem.UIRoot.ShowResult(true);
    }

    public override IEnumerator StateEnd()
    {
        mGameSystem.UIRoot.ShowResult(false);
        yield return null;
    }
}
