using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class StateWhiteTurn : State
{
    public StateWhiteTurn(GameSystem game_system) : base(game_system) { }

    public override IEnumerator StateStart()
    {
        mGameSystem.UIRoot.WhiteTurn();
        yield return new WaitForSeconds(1);

        RandomPlaceDisc();

        yield return new WaitForSeconds(1);
        mGameSystem.SetState(new StateBlackTurn(mGameSystem));
    }

    public override IEnumerator StateEnd()
    {
        yield return null;
    }

    public void RandomPlaceDisc()
    {
        List<Vector2Int> available_pos_list = mGameSystem.Modelboard.GetAllValidPos(DiscSide.White);
        if (available_pos_list.Count <= 0)
        {
            // pass this turn if there is no available place
            return;
        }
        // Random place a disc
        // Will use algorithms to decide where to place
        int drop_pos_idx = UnityEngine.Random.Range(0, available_pos_list.Count);
        Vector2Int pos = available_pos_list[drop_pos_idx];

        Debug.Log($"The white side drops disc at ({pos})");

        DiscSide side = DiscSide.White;
        mGameSystem.Modelboard.PlaceDisc(pos, side);
    }
}
