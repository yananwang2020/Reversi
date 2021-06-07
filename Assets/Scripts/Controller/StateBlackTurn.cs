using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

class StateBlackTurn: State
{
    public StateBlackTurn(GameSystem game_system) : base(game_system) { }

    public override IEnumerator StateStart()
    {
        mGameSystem.ui_root.BlackTurn();
        yield return null;
    }

    public override IEnumerator StateEnd()
    {
        yield return null;
    }

    public override IEnumerator DropDisc(int pos_x, int pos_y)
    {
        Debug.Log($"DropDisc at ({pos_x}, {pos_y})");
        mGameSystem.modelboard.ChangeDisc(pos_x, pos_x, DiscValue.Black);

        int blackScore;
        int whiteScore;
        mGameSystem.modelboard.GetScores(out blackScore, out whiteScore);
        mGameSystem.ui_root.SetScores(blackScore, whiteScore);

        mGameSystem.board.SetDiscs(mGameSystem.modelboard.mDiscInfos);

        yield return new WaitForSeconds(1);
        mGameSystem.SetState(new StateWhiteTurn(mGameSystem));
    }
}
