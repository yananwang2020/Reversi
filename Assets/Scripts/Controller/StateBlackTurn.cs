using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class StateBlackTurn : State
{
    public StateBlackTurn(GameSystem game_system) : base(game_system) { }
    List<Vector2Int> available_pos_list;

    public override IEnumerator StateStart()
    {
        mGameSystem.uiRoot.BlackTurn();

        available_pos_list = mGameSystem.modelboard.GetAllValidPos(DiscSide.Black);
        if (available_pos_list.Count > 0)
        {
            // Visualise all available positions in the board
            mGameSystem.gameBoard.ShowAvailablePos(available_pos_list);
        }
        else 
        {
            // pass this turn if there is no available place
            mGameSystem.SetState(new StateWhiteTurn(mGameSystem));
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

        if (available_pos_list.Contains(pos))
        {
            DiscSide side = DiscSide.Black;
            mGameSystem.modelboard.PlaceDisc(pos, side);
        
            yield return new WaitForSeconds(1);
            mGameSystem.SetState(new StateWhiteTurn(mGameSystem));
        }
    }
}
