using System.Collections;
using UnityEngine;

namespace Reversi.Controller
{
    class StateGaming : State
    {
        public StateGaming(GameSystem game_system) : base(game_system) { }

        public override IEnumerator StateStart()
        {
            // Step 1: Visualise some content
            myGameSystem.Modelboard.SetGameStartDiscs();
            myGameSystem.GameBoard.gameObject.SetActive(true);
            myGameSystem.UIRoot.ShowGaming(true);

            yield return new WaitForSeconds(1);

            // Step 2: Go to the black turn
            myGameSystem.SetState(new StateBlackTurn(myGameSystem));
        }

        public override IEnumerator StateEnd()
        {
            yield return null;
        }
    }
}