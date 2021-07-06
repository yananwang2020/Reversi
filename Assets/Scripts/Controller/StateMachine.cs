using UnityEngine;

namespace Reversi.Controller
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State CrtState;

        public void SetState(State state)
        {
            if (CrtState != null)
            {
                StartCoroutine(CrtState.StateEnd());
            }

            CrtState = state;
            StartCoroutine(CrtState.StateStart());
            Debug.Log("SetState: " + state.ToString());
        }
    }
}