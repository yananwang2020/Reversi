using Reversi.Models;
using System.Collections.Generic;
using UnityEngine;

namespace Reversi.Monos
{
    public class GameBoard : MonoBehaviour
    {
        public GameObject PointTopLeft;
        public GameObject PointBottomRight;
        public GameObject PrefDisc;

        Vector3[,] discPositions;
        Disc[,] discs;
        Vector2 discSize;

        public void InitDiscPos()
        {
            discPositions = new Vector3[GlobalConfigs.Lines, GlobalConfigs.Lines];
            Vector3 pos_tl = PointTopLeft.transform.localPosition;
            Vector3 pos_br = PointBottomRight.transform.localPosition;
            Vector3 pos_gap = (pos_br - pos_tl) / (GlobalConfigs.Lines - 1);

            for (int i = 0; i < GlobalConfigs.Lines; i++)
            {
                for (int j = 0; j < GlobalConfigs.Lines; j++)
                {
                    Vector3 pos_i = pos_tl + new Vector3(pos_gap.x * j, pos_gap.y * i, 0);
                    discPositions[i, j] = pos_i;


                }
            }

            RectTransform rt = PointTopLeft.GetComponent(typeof(RectTransform)) as RectTransform;
            discSize = rt.rect.size;
            Debug.Log($"discRect {discSize}");
        }

        public void InitDiscs()
        {
            Debug.Log("InitDiscs");
            discs = new Disc[GlobalConfigs.Lines, GlobalConfigs.Lines];
            for (int i = 0; i < GlobalConfigs.Lines; i++)
            {
                for (int j = 0; j < GlobalConfigs.Lines; j++)
                {
                    GameObject disc_ij = Instantiate(PrefDisc) as GameObject;
                    disc_ij.transform.SetParent(this.transform);
                    disc_ij.transform.localPosition = discPositions[i, j];
                    disc_ij.transform.localScale = Vector3.one;
                    disc_ij.GetComponent<RectTransform>().sizeDelta = discSize;
                    disc_ij.GetComponent<BoxCollider2D>().size = discSize;
                    disc_ij.name = $"{PrefDisc.name}_{i}_{j}";
                    discs[i, j] = disc_ij.GetComponent<Disc>();
                }
            }
        }

        public void SetDiscs(DiscInfo[,] discinfos)
        {
            Debug.Log("SetDiscs");
            for (int i = 0; i < GlobalConfigs.Lines; i++)
            {
                for (int j = 0; j < GlobalConfigs.Lines; j++)
                {
                    discs[i, j].SetInfo(discinfos[i, j]);
                }
            }
        }

        public void ShowAvailablePos(List<Vector2Int> available_pos_list)
        {
            foreach (Vector2Int pos in available_pos_list)
            {
                discs[pos.x, pos.y].ShowAvailableColor();
            }
        }

    }
}