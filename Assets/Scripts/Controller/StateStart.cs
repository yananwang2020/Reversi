using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

namespace Reversi
{
    class StateStart : State
    {
        protected BattleBehaviour battle_behaviour;

        public override IEnumerator Start()
        {
            Debug.Log("Game Start!");

            yield return new WaitForSeconds(2f);

            
        }

        private void InitBoard()
        {

        }
    }
}
