using UnityEngine;
using System.Collections.Generic;

public struct DiscIndex
{
    int Row;
    int Column;
}

public enum DiscValue : short
{
    Black = -1,
    None = 0,
    White = 1
}

public class ModelBoard
{
    List<int> t = new List<int>();
    Dictionary<DiscIndex, DiscValue> disc_values;
}
