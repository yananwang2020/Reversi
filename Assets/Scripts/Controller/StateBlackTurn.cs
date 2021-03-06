using Reversi.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reversi.Controller
{
    class StateBlackTurn : State
    {
        public StateBlackTurn(GameSystem game_system) : base(game_system) { }
        List<Vector2Int> availablePositions;

        public override IEnumerator StateStart()
        {
            myGameSystem.UIRoot.BlackTurn();

            availablePositions = myGameSystem.Modelboard.GetAllValidPos(DiscSide.Black);
            if (availablePositions.Count > 0)
            {
                // Visualise all available positions in the board
                myGameSystem.GameBoard.ShowAvailablePos(availablePositions);
            }
            else
            {
                // pass this turn if there is no available place
                myGameSystem.SetState(new StateWhiteTurn(myGameSystem));
            }

            yield return null;
        }

        public override IEnumerator StateEnd()
        {
            yield return null;
        }

        public override IEnumerator PlaceDisc(Vector2Int pos)
        {
            Debug.Log($"The black side drops disc at ({pos})");

            if (availablePositions.Contains(pos))
            {
                DiscSide side = DiscSide.Black;
                myGameSystem.Modelboard.PlaceDisc(pos, side);

                if (myGameSystem.Modelboard.CheckGameEnd())
                {
                    myGameSystem.SetState(new StateResult(myGameSystem));
                    yield return null;
                }

                else
                {
                    yield return new WaitForSeconds(GlobalConfigs.TurnIntervalSec);
                    myGameSystem.SetState(new StateWhiteTurn(myGameSystem));
                }
            }
        }
    }
}