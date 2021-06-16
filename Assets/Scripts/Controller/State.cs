using System.Collections;
using UnityEngine;

public abstract class State
{
    protected GameSystem mGameSystem;

    public State(GameSystem gs)
    {
        mGameSystem = gs;
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
