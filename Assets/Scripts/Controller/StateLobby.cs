﻿using System;
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
        mGameSystem.UIRoot.ShowLobby(true);
        yield return null;
    }

    public override IEnumerator StateEnd()
    {
        mGameSystem.UIRoot.ShowLobby(false);
        yield return null;
    }
}
