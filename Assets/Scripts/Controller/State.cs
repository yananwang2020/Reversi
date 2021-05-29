using System.Collections;
using UnityEngine;

namespace Reversi
{
    public abstract class State
    {
        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual IEnumerator Pause()
        {
            yield break;
        }

        public virtual IEnumerator End()
        {
            yield break;
        }

        public virtual IEnumerator DropDisc(DiscInfo disc_info)
        {
            yield break;
        }
    }
}
