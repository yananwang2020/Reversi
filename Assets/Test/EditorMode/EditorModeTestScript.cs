using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Reversi.Models;
using UnityEngine;
using UnityEngine.TestTools;

public class EditorModeTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestModelInitFunction()
    {
        ModelBoard mb = new ModelBoard();

        mb.InitBoard();
        mb.SetGameStartDiscs();

        DiscInfo[,] expected_disc_info = new DiscInfo[8, 8];
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                expected_disc_info[x, y] = new DiscInfo(x, y, DiscSide.None);
            }
        }
        expected_disc_info[3, 4].Side = DiscSide.Black;
        expected_disc_info[4, 3].Side = DiscSide.Black;
        expected_disc_info[3, 3].Side = DiscSide.White;
        expected_disc_info[4, 4].Side = DiscSide.White;

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Assert.AreEqual(expected_disc_info[x, y].Side, mb.DiscInfos[x, y].Side);
            }
        }

        foreach (var disc_info in mb.DiscInfos)
        {
            if (GlobalConfigs.InitInfo.ContainsKey(disc_info.Pos))
            {
                Assert.AreEqual(GlobalConfigs.InitInfo[disc_info.Pos], disc_info.Side);
            }
            else
            {
                Assert.AreEqual(DiscSide.None, disc_info.Side);
            }
        }

        List<Vector2Int> black_available_pos = mb.GetAllValidPos(DiscSide.Black);
        // Use the Assert class to test conditions
    }

    [Test]
    public void TestModelAvailableFunction()
    {
        ModelBoard mb = new ModelBoard();

        mb.InitBoard();
        mb.SetGameStartDiscs();

        List<Vector2Int> compare_pos = new List<Vector2Int>()
        {
            new Vector2Int(2, 3),
            new Vector2Int(3, 2),
            new Vector2Int(4, 5),
            new Vector2Int(5, 4)
        };
        List<Vector2Int> valid_pos = mb.GetAllValidPos(DiscSide.Black);
        Assert.AreEqual(valid_pos, valid_pos);

        Dictionary<Vector2Int, Vector2Int> expected_dict = new Dictionary<Vector2Int, Vector2Int>
        {
            { new Vector2Int(2, 3), new Vector2Int (3, 3)},
            { new Vector2Int(3, 2), new Vector2Int (3, 3)},
            { new Vector2Int(4, 5), new Vector2Int (4, 4)},
            { new Vector2Int(5, 4), new Vector2Int (4, 4)},
        };
        foreach (Vector2Int pos in valid_pos)
        {
            Assert.Contains(expected_dict[pos], mb.FlippedDiscsWhenPlace[pos]);
        }

    }
}
