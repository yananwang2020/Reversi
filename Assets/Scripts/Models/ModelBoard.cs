using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiscInfo
{
    public Vector2Int Pos;
    public DiscSide Side;
    public DiscInfo(int x, int y, DiscSide s)
    {
        Pos = new Vector2Int(x, y);
        Side = s;
    }

    public bool IsEdge()
    {
        return (Pos.x == 0 || Pos.y == 0 || Pos.x == 7 || Pos.y == 7);
    }

    public override string ToString()
    {
        return ($"Disc at {Pos} with value {Side}");
    }
}

public enum DiscSide : int
{
    Black = -1,
    None = 0,
    White = 1
}

public class ModelBoard
{
    public delegate void OnDiscInfoChange(DiscInfo[,] disc_info);
    public OnDiscInfoChange mOnDiscInfoChange;

    // The current discs information on the board
    public DiscInfo[,] mDiscInfos = new DiscInfo[8, 8];

    // The to-flipped discs when the key pos is placed
    public Dictionary<Vector2Int, List<Vector2Int>> mFlippedDiscsWhenPlace = new Dictionary<Vector2Int, List<Vector2Int>>();

    // All eight direction: left, right, up, down
    // up left, upright, down left, down right,
    List<Vector2Int> mDirections = new List<Vector2Int>()
    {
        new Vector2Int(0, 1),
        new Vector2Int(0, -1),
        new Vector2Int(1, -1),
        new Vector2Int(1, 0),
        new Vector2Int(1, 1),
        new Vector2Int(-1, -1),
        new Vector2Int(-1, 0),
        new Vector2Int(-1, 1)
    };

    public void InitBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                DiscInfo disc_info = new DiscInfo(i, j, DiscSide.None);
                mDiscInfos[i, j] = disc_info;
            }
        }

        mDiscInfos[3, 3].Side = DiscSide.White;
        mDiscInfos[4, 4].Side = DiscSide.White;
        mDiscInfos[3, 4].Side = DiscSide.Black;
        mDiscInfos[4, 3].Side = DiscSide.Black;

        if (mOnDiscInfoChange != null)
        {
            mOnDiscInfoChange(mDiscInfos);
        }
    }

    public void PlaceDisc(Vector2Int pos, DiscSide side)
    {
        mDiscInfos[pos.x, pos.y].Side = side;

        foreach (Vector2Int flipped_disc in mFlippedDiscsWhenPlace[pos])
        {
            mDiscInfos[flipped_disc.x, flipped_disc.y].Side = side;
        }
        //mOnDiscInfoChange(mDiscInfos);
    }

    public List<Vector2Int> GetAllValidPos(DiscSide side)
    {
        mFlippedDiscsWhenPlace.Clear();
        List<Vector2Int> pos_list = new List<Vector2Int>();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Vector2Int pos = new Vector2Int(i, j);
                List<Vector2Int> flipped_discs;
                if (CheckValid(pos, side, out flipped_discs))
                {
                    pos_list.Add(pos);
                    mFlippedDiscsWhenPlace.Add(pos, flipped_discs);
                }
            }
        }
        return pos_list;
    }

    public bool CheckValid(Vector2Int pos, DiscSide side, out List<Vector2Int> flipped_discs)
    {
        flipped_discs = new List<Vector2Int>();

        // if the position is occupied
        if (mDiscInfos[pos.x, pos.y].Side != DiscSide.None)
        {
            return false;
        }

        // Check all discs in the 8 directions
        foreach (Vector2Int direct in mDirections)
        {
            // checking stages
            int stage = 0;
            Vector2Int pos_in_direct = pos;
            List<Vector2Int> routine_discs = new List<Vector2Int>();

            // check all positions in the direction
            // when pos out the board or is empty : break loop
            // when stage == 0 & find opposite side discs: set stage = 1
            // when stage == 1 & find the same side disc at the end : set stage = 2 and end the loop
            while (true)
            {
                pos_in_direct += direct;

                // out the board or is empty
                if (!IsPosOnBoard(pos_in_direct) || mDiscInfos[pos_in_direct.x, pos_in_direct.y].Side == DiscSide.None)
                {
                    break;
                }

                routine_discs.Add(pos_in_direct);
                if (stage == 0)
                {
                    // find the sequencial opposite sides along the position
                    if ((int)mDiscInfos[pos_in_direct.x, pos_in_direct.y].Side * (int)side == -1)
                    {
                        stage = 1;
                    }
                    else
                    {
                        break;
                    }
                }

                if (stage == 1)
                {
                    // find the same side disc, end the finding process
                    if ((int)mDiscInfos[pos_in_direct.x, pos_in_direct.y].Side * (int)side == 1)
                    {
                        stage = 2;
                        break;
                    }
                }
            }

            if (stage == 2)
            {
                flipped_discs.AddRange(routine_discs);
                continue;
            }
        }

        if (flipped_discs.Count > 0)
            return true;

        return false;
    }

    bool IsPosOnBoard(Vector2Int pos)
    {
        return (pos.x >= 0 && pos.y >= 0 && pos.x <= 7 && pos.y <= 7);
    }

    public void BindOnDiscInfoChange(OnDiscInfoChange bind_method)
    {
        mOnDiscInfoChange += bind_method;
    }

    public void GetScores(out int black_score, out int white_score)
    {
        black_score = 0;
        white_score = 0;
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                switch (mDiscInfos[x, y].Side)
                {
                    case DiscSide.Black:
                        black_score++;
                        break;

                    case DiscSide.White:
                        white_score++;
                        break;

                }
            }
        }
    }
}
