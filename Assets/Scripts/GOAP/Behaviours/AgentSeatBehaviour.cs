using UnityEngine;

public class AgentSeatBehaviour : MonoBehaviour
{
    public TableBehaviour Table;
    public Vector3 SeatPosition;
    public bool HasSeat = false;

    public void Sitdown(TableBehaviour table)
    {
        this.Table = table;
        Table.SitDown(this);       
    }

    public void Standup()
    {
        Table.StandUp(this);
        this.Table = null;
   
    }
}
