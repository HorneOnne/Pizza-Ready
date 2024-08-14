using UnityEngine;

public class AgentSeatBehaviour : MonoBehaviour
{
    public TableBehaviour Table;
    public bool IsSitDown = false;
    public bool HasSeat = false;

    public void Sitdown(TableBehaviour table)
    {
        IsSitDown = true;
        table.SitDown(this);       
    }

    public void SetTargetTable(TableBehaviour table)
    {
        this.Table = table;
    }

    public void Standup()
    {
        Table.StandUp(this);
        this.Table = null;
        IsSitDown = false;

    }
}
