using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class StateBlackTurn : State
{
    public StateBlackTurn(GameSystem game_system) : base(game_system) { }

    public override IEnumerator StateStart()
    {
        mGameSystem.ui_root.BlackTurn();

        List<Vector2Int> available_pos_list = mGameSystem.modelboard.GetAllValidPos(DiscSide.Black);
        if (available_pos_list.Count > 0)
        {
            // Visualise all available positions in the board
            mGameSystem.board.ShowAvailablePos(available_pos_list);
        }

        yield return null;
    }

    public override IEnumerator StateEnd()
    {
        yield return null;
    }

    public override IEnumerator PlaceDisc(Vector2Int pos)
    {
        Debug.Log($"The black side drops disc at ({pos})");

        DiscSide side = DiscSide.Black;
        mGameSystem.modelboard.PlaceDisc(pos, side);
        int blackScore;
        int whiteScore;
        mGameSystem.modelboard.GetScores(out blackScore, out whiteScore);
        mGameSystem.ui_root.SetScores(blackScore, whiteScore);

        mGameSystem.board.SetDiscs(mGameSystem.modelboard.mDiscInfos);

        yield return new WaitForSeconds(1);
        mGameSystem.SetState(new StateWhiteTurn(mGameSystem));

    }
}
