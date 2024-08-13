using UnityEngine;

public class AgentQueuingBehaviour : MonoBehaviour
{
    private WaitingLane _waitingLane;
    public bool IsWaitingInQueue;
    public Transform QueueTransform;
    public int QueueIndex = 999;

    private void Awake()
    {
        _waitingLane = FindObjectOfType<WaitingLane>();
        IsWaitingInQueue = false;
    }



}
