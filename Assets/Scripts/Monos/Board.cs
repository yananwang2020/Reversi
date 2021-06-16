using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject pointTopLeft;
    public GameObject pointBottomRight;
    public GameObject prefDisc;

    private int lines = 8;
    private Vector3[,] discPositions;
    private Disc[,] discs;

    public void InitDiscPos()
    {
        discPositions = new Vector3[lines, lines];
        Vector3 pos_tl = pointTopLeft.transform.localPosition;
        Vector3 pos_br = pointBottomRight.transform.localPosition;
        Vector3 pos_gap = (pos_br - pos_tl) / (lines - 1);

        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < lines; j++)
            {
                Vector3 pos_i = pos_tl + new Vector3(pos_gap.x * j, pos_gap.y * i, 0);
                discPositions[i,j] = pos_i;
            }
        }
    }

    public void InitDiscs()
    {
        Debug.Log("InitDiscs");
        discs = new Disc[lines, lines];
        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < lines; j++)
            {
                GameObject disc_ij = Instantiate(prefDisc) as GameObject;
                disc_ij.transform.SetParent(this.transform);
                disc_ij.transform.localPosition = discPositions[i,j];
                disc_ij.transform.localScale = Vector3.one;
                disc_ij.name = $"{prefDisc.name}_{i}_{j}";
                discs[i, j] = disc_ij.GetComponent<Disc>();
            }
        }
    }

    public void SetDiscs(DiscInfo[,] discinfos)
    {
        Debug.Log("SetDiscs");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                discs[i, j].SetInfo(discinfos[i, j]);
            }
        }
    }

    public void ShowAvailablePos(List<Vector2Int> available_pos_list)
    {
        foreach(Vector2Int pos in available_pos_list)
        {
            discs[pos.x, pos.y].ShowAvailableColor();
        }
    }
}
