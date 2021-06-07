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

    public virtual IEnumerator DropDisc(int pos_x, int pos_y)
    {
        yield break;
    }
}
