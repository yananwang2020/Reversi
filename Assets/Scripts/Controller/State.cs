using System.Collections;
using UnityEngine;

public abstract class State
{
    protected GameSystem game_system;

    public State(GameSystem gs)
    {
        game_system = gs;
    }

    public virtual IEnumerator StateStart()
    {
        yield break;
    }

    public virtual IEnumerator StateEnd()
    {
        yield break;
    }

    public virtual IEnumerator DropDisc(DiscInfo disc_info)
    {
        yield break;
    }
}
