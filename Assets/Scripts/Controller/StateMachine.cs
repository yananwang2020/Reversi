using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Reversi
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State crt_state;

        public void SetState(State state)
        {
            crt_state = state;
            StartCoroutine(crt_state.Start());
        }
    }
}
