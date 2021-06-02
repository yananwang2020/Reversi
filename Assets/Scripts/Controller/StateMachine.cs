using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State crt_state;

    public void SetState(State state)
    {
        if (crt_state != null)
        {
            StartCoroutine(crt_state.StateEnd());
        }

        crt_state = state;
        StartCoroutine(crt_state.StateStart());
    }
}
