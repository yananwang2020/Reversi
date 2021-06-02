using System.Collections.Generic;

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
}

public enum DiscValue : int
{
    Black = -1,
    None = 0,
    White = 1
}

public class ModelBoard
{
    public DiscInfo[,] disc_infos;

    public void InitBoard()
    {
        disc_infos = new DiscInfo[8, 8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                DiscInfo disc_info = new DiscInfo(i, j, DiscValue.None);
                disc_infos[i, j] = disc_info;
            }
        }

        disc_infos[3, 3].V = DiscValue.White;
        disc_infos[4, 4].V = DiscValue.White;
        disc_infos[3, 4].V = DiscValue.Black;
        disc_infos[4, 3].V = DiscValue.Black;
    }

    private void ChangeDisc(int x, int y, DiscValue v)
    {
        //DiscInfo disc_item = disc_infos.Find(item => (item.X == x && item.Y == y));

        //if (disc_item != null)
        //{
        //    disc_item.V = v;
        //}
    }
    private void is_valid(DiscInfo disc_info)
    {


    }
}
