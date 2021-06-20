using System.Collections;
using UnityEngine;

public abstract class State
{
    protected GameSystem myGameSystem;

    public State(GameSystem game_system)
    {
        myGameSystem = game_system;
    }

    public virtual IEnumerator StateStart()
    {
        yield break;
    }

    public virtual IEnumerator StateEnd()
    {
        yield break;
    }
    
    public virtual IEnumerator PlaceDisc(Vector2Int pos)
    {
        yield break;
    }
}
