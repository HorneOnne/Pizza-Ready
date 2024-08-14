using UnityEngine;
using System.Collections.Generic;

public class TableCollection : MonoBehaviour
{
    public List<TableBehaviour> Tables = new();

    public void Add(TableBehaviour table)
    {
        Tables.Add(table);
    }

    public void Remove(TableBehaviour table)
    {
        Tables.Remove(table);
    }
}