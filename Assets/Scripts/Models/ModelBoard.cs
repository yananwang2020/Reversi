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
    List<DiscInfo> disc_infos = new List<DiscInfo>();

    private void InitBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                DiscInfo dis_none = new DiscInfo(i, j, DiscValue.White);
                disc_infos.Add(dis_none);
            }
        }

        DiscInfo w1 = new DiscInfo(3, 3, DiscValue.White);
        DiscInfo w2 = new DiscInfo(4, 4, DiscValue.White);
        DiscInfo w3 = new DiscInfo(3, 4, DiscValue.Black);
        DiscInfo w4 = new DiscInfo(4, 3, DiscValue.Black);
        disc_infos.Add(w1);
        disc_infos.Add(w1);
        disc_infos.Add(w1);
        disc_infos.Add(w1);
    }

    private void ChangeDisc(int x, int y, DiscValue v)
    {
        DiscInfo disc_item = disc_infos.Find(item => (item.X == x && item.Y == y));

        if (disc_item != null)
        {
            disc_item.V = v;
        }
    }
    private void is_valid(DiscInfo disc_info)
    {


    }
}
