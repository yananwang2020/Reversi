using System.Collections;
using UnityEngine;

class StateResult : State
{
    public StateResult(GameSystem game_system) : base(game_system) { }

    public override IEnumerator StateStart()
    {
        yield return new WaitForSeconds(3);
        // Hide things from the gameing
        myGameSystem.GameBoard.gameObject.SetActive(false);
        myGameSystem.UIRoot.ShowGaming(false);

        // Show things for the result
        myGameSystem.UIRoot.ShowResult(true);
    }

    public override IEnumerator StateEnd()
    {
        myGameSystem.UIRoot.ShowResult(false);
        yield return null;
    }
}
