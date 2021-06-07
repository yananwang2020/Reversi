using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State mCrtState;

    public void SetState(State state)
    {
        if (mCrtState != null)
        {
            StartCoroutine(mCrtState.StateEnd());
        }

        mCrtState = state;
        StartCoroutine(mCrtState.StateStart());
        Debug.Log("SetState: " + state.ToString());
    }
}
