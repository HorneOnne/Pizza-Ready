using UnityEngine;

public class TableBehaviour : MonoBehaviour
{
    public int EmptySeatCount = 2;

    public bool TryAdd()
    {
        if(EmptySeatCount == 0)
        {
            return false;
        }

        EmptySeatCount--;
        return true;
    }

    public void Remove()
    {
        EmptySeatCount++;
    }

    public bool HasSeat()
    {
        return EmptySeatCount > 0;
    }
}
