using System;
using System.Collections;
using UnityEngine;

namespace Reversi
{
    class StateWhiteTurn : State
    {
        public override IEnumerator Start()
        {
            Console.WriteLine("StateWhiteTurn Start");

            yield return new WaitForSeconds(1f);

        }

        public override IEnumerator DropDisc(DiscInfo disc_info)
        {
            yield break;
        }
    }
}
