using System.Collections.Generic;
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
    public OnDiscInfoChange EventOnDiscInfoRefresh;

    public delegate void OnScoreChange(int black_score, int white_score);
    public OnScoreChange EventOnScoreChange;

    // The current discs information on the board
    public DiscInfo[,] DiscInfos = new DiscInfo[Configs.Lines, Configs.Lines];

    // The to-flipped discs when the key pos is placed
    public Dictionary<Vector2Int, List<Vector2Int>> FlippedDiscsWhenPlace = new Dictionary<Vector2Int, List<Vector2Int>>();

    // All eight direction: left, right, up, down
    // up left, upright, down left, down right,
    List<Vector2Int> directions = new List<Vector2Int>()
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
        for (int i = 0; i < Configs.Lines; i++)
        {
            for (int j = 0; j < Configs.Lines; j++)
            {
                DiscInfo disc_info = new DiscInfo(i, j, DiscSide.None);
                DiscInfos[i, j] = disc_info;
            }
        }
    }

    public void SetGameStartDiscs()
    {
        for (int i = 0; i < Configs.Lines; i++)
        {
            for (int j = 0; j < Configs.Lines; j++)
            {
                DiscInfos[i, j].Side = DiscSide.None;
            }
        }

        foreach (KeyValuePair<Vector2Int, DiscSide> InitInfoItem in Configs.InitInfo)
        {
            DiscInfos.GetItem(InitInfoItem.Key).Side = InitInfoItem.Value;
        }

        TriggerDelegates();
    }

    public void PlaceDisc(Vector2Int pos, DiscSide side)
    {
        DiscInfos[pos.x, pos.y].Side = side;

        foreach (Vector2Int flipped_disc in FlippedDiscsWhenPlace[pos])
        {
            DiscInfos.GetItem(flipped_disc).Side = side;
        }

        TriggerDelegates();
    }

    public List<Vector2Int> GetAllValidPos(DiscSide side)
    {
        FlippedDiscsWhenPlace.Clear();
        List<Vector2Int> pos_list = new List<Vector2Int>();
        for (int i = 0; i < Configs.Lines; i++)
        {
            for (int j = 0; j < Configs.Lines; j++)
            {
                Vector2Int pos = new Vector2Int(i, j);
                List<Vector2Int> flipped_discs;
                if (CheckValid(pos, side, out flipped_discs))
                {
                    pos_list.Add(pos);
                    FlippedDiscsWhenPlace.Add(pos, flipped_discs);
                }
            }
        }
        return pos_list;
    }

    void TriggerDelegates()
    {
        if (EventOnDiscInfoRefresh != null)
        {
            EventOnDiscInfoRefresh(DiscInfos);
        }

        if (EventOnScoreChange != null)
        {
            int black_score = 0;
            int white_score = 0;
            GetScores(out black_score, out white_score);
            EventOnScoreChange(black_score, white_score);
        }
    }

    public bool CheckGameEnd()
    {
        for (int i = 0; i < Configs.Lines; i++)
        {
            for (int j = 0; j < Configs.Lines; j++)
            {
                // Game is not end if there are vacant positions.
                if (DiscInfos[i, j].Side == DiscSide.None)
                {
                    return false;
                }
            }
        }
        return true;
    }

    bool CheckValid(Vector2Int pos, DiscSide side, out List<Vector2Int> flipped_discs)
    {
        flipped_discs = new List<Vector2Int>();

        // if the position is occupied
        if (DiscInfos.GetItem(pos).Side != DiscSide.None)
        {
            return false;
        }

        // Check all discs in the 8 directions
        foreach (Vector2Int direct in directions)
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
                if (!IsPosOnBoard(pos_in_direct) || DiscInfos.GetItem(pos_in_direct).Side == DiscSide.None)
                {
                    break;
                }

                routine_discs.Add(pos_in_direct);
                if (stage == 0)
                {
                    // find the sequencial opposite sides along the position
                    if ((int)DiscInfos.GetItem(pos_in_direct).Side * (int)side == -1)
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
                    if ((int)DiscInfos.GetItem(pos_in_direct).Side * (int)side == 1)
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
        return (pos.x >= 0 && pos.y >= 0 && pos.x < Configs.Lines && pos.y < Configs.Lines);
    }

    void GetScores(out int black_score, out int white_score)
    {
        black_score = 0;
        white_score = 0;
        for (int x = 0; x < Configs.Lines; x++)
        {
            for (int y = 0; y < Configs.Lines; y++)
            {
                switch (DiscInfos[x, y].Side)
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
