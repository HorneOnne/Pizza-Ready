using UnityEngine;

public class SeatBehaviour : MonoBehaviour
{
    public TableBehaviour Table;

    public void Sitdown(TableBehaviour table)
    {
        this.Table = table;
    }

    public void Standup()
    {
        this.Table = null;
    }
}