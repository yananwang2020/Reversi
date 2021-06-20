using System.Collections;
using UnityEngine;

class StateLobby : State
{
    public StateLobby(GameSystem game_system) : base(game_system) { }

    public override IEnumerator StateStart()
    {
        Debug.Log("Game Start!");
        myGameSystem.UIRoot.ShowLobby(true);
        yield return null;
    }

    public override IEnumerator StateEnd()
    {
        myGameSystem.UIRoot.ShowLobby(false);
        yield return null;
    }
}
