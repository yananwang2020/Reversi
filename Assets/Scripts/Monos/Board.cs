using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject point_top_left;
    public GameObject point_bottom_right;
    public GameObject pref_disc;

    private int lines = 8;
    private Vector3[,] disc_positions;
    private Disc[,] discs;

    // Start is called before the first frame update

    public void InitDiscPos()
    {
        disc_positions = new Vector3[lines, lines];
        Vector3 pos_tl = point_top_left.transform.localPosition;
        Vector3 pos_br = point_bottom_right.transform.localPosition;
        Vector3 pos_gap = (pos_br - pos_tl) / (lines - 1);

        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < lines; j++)
            {
                Vector3 pos_i = pos_tl + new Vector3(pos_gap.x * i, pos_gap.y * j, 0);
                disc_positions[i,j] = pos_i;
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
                GameObject disc_i = Instantiate(pref_disc) as GameObject;
                disc_i.transform.SetParent(this.transform);
                disc_i.transform.localPosition = disc_positions[i,j];
                discs[i, j] = disc_i.GetComponent<Disc>();
                discs[i, j].SetValue(DiscValue.None);
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
                discs[i, j].SetValue(discinfos[i, j].V);
            }
        }
    }
}
