using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBoard : MonoBehaviour
{
    public GameObject point_top_left;
    public GameObject point_bottom_right;
    public GameObject pref_chess;

    private int lines = 8;
    private Vector3[,] disc_positions;

    // Start is called before the first frame update
    void Start()
    {
        init_disc_positions();
        test_spawn_discs();
    }

    void init_disc_positions()
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

    void test_spawn_discs()
    {
        Debug.Log("test_spawn_chess");
        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < lines; j++)
            {
                GameObject disc_i = Instantiate(pref_chess) as GameObject;
                disc_i.transform.SetParent(this.transform);
                disc_i.transform.localPosition = disc_positions[i,j];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
