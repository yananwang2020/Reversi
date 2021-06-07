using System.Collections.Generic;
using System.Linq;

public class DiscInfo
{
    public int X;
    public int Y;
    public DiscValue V;
    public DiscInfo(int x, int y, DiscValue v)
    {
        X = x;
        Y = y;
        V = v;
    }

    public bool IsEdge()
    {
        return (X == 0 || Y == 0 || X == 7 || Y == 7);
    }

    public override string ToString()
    {
        return ($"Disc at {X},{Y} with value {V}");
    }
}

public enum DiscValue : int
{
    Black = -1,
    None = 0,
    White = 1
}

public class ModelBoard
{
    public delegate void OnDiscInfoChange(DiscInfo[,] disc_info);
    public OnDiscInfoChange mOnDiscInfoChange;
    public DiscInfo[,] mDiscInfos;

    public void InitBoard()
    {
        mDiscInfos = new DiscInfo[8, 8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                DiscInfo disc_info = new DiscInfo(i, j, DiscValue.None);
                mDiscInfos[i, j] = disc_info;
            }
        }

        mDiscInfos[3, 3].V = DiscValue.White;
        mDiscInfos[4, 4].V = DiscValue.White;
        mDiscInfos[3, 4].V = DiscValue.Black;
        mDiscInfos[4, 3].V = DiscValue.Black;

        if(mOnDiscInfoChange != null)
        {
            mOnDiscInfoChange(mDiscInfos);
        }
    }

    public void ChangeDisc(int x, int y, DiscValue v)
    {
        mDiscInfos[x, y].V = v;
        //mOnDiscInfoChange(mDiscInfos);
    }

    private void is_valid(DiscInfo disc_info)
    {


    }

    public void BindOnDiscInfoChange(OnDiscInfoChange bind_method)
    {
        mOnDiscInfoChange += bind_method;
    }

    public void GetScores(out int black_score, out int white_score)
    {
        black_score = 0;
        white_score = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                switch (mDiscInfos[i, j].V)
                {   
                    case DiscValue.Black:
                        black_score++;
                    break;

                    case DiscValue.White:
                        white_score++;
                    break;

                }
            }
        }
    }
}
