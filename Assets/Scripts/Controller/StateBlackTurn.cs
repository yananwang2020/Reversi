using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Reversi
{
    class StateBlackTurn : State
    {
        public override IEnumerator Start()
        {
            Console.WriteLine("StateBlackTurn Start");

            yield return new WaitForSeconds(1f);
        }
    }
}
