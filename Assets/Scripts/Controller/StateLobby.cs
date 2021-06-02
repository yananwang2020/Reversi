using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

class StateLobby : State
{
    public StateLobby(GameSystem gamesystem) : base(gamesystem) { }

    public override IEnumerator StateStart()
    {
        Debug.Log("Game Start!");

        yield return new WaitForSeconds(2f);

        game_system.ui_root.ShowLobby(true);
    }

    public override IEnumerator StateEnd()
    {
        game_system.ui_root.ShowLobby(false);

        yield return null;
    }
}
