using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

class StateGaming : State
{
    public StateGaming(GameSystem gamesystem) : base(gamesystem) { }

    public override IEnumerator StateStart()
    {
        game_system.board.InitDiscPos();
        game_system.board.InitDiscs();

        game_system.modelboard.InitBoard();
        game_system.board.SetDiscs(game_system.modelboard.disc_infos);

        yield return new WaitForSeconds(1);
    }

    public override IEnumerator StateEnd()
    {
        return base.StateEnd();
    }
}
