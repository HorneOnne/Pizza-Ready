using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingLane : MonoBehaviour
{
    public List<Transform> WaitingPoints;
    [SerializeField] private AgentQueuingBehaviour[] _customerQueue;


    private void Awake()
    {
        _customerQueue = new AgentQueuingBehaviour[WaitingPoints.Count];
    }

    public void Join(AgentQueuingBehaviour agent)
    {
        if (agent.IsWaitingInQueue) return;
        for (int i = 0; i < _customerQueue.Length; i++)
        {
            if (_customerQueue[i] == null)
            {
                _customerQueue[i] = agent;
                agent.QueueTransform = WaitingPoints[i];
                agent.IsWaitingInQueue = true;
                agent.QueueIndex = i;
                agent.GetComponent<AgentMoveBehaviour>().MoveTo(WaitingPoints[i].position);
                Debug.Log($"Join: {i}");
                return;
            }
        }
    }


    public void Out(AgentQueuingBehaviour agent)
    {
        Debug.Log("Out");
        if (agent.IsWaitingInQueue == false) return;
        int index = System.Array.IndexOf(_customerQueue, agent);

        if (index == -1)
            return;

        for (int i = index; i < _customerQueue.Length - 1; i++)
        {
            _customerQueue[i] = _customerQueue[i + 1];

            if (_customerQueue[i] == null) continue;

            //_customerQueue[i].GetComponent<AgentMoveBehaviour>().ChangeTarget(WaitingPoints[i].position);
            _customerQueue[i].GetComponent<AgentMoveBehaviour>().MoveTo(WaitingPoints[i].position);
            _customerQueue[i].QueueTransform = WaitingPoints[i];
            _customerQueue[i].QueueIndex = i;
        }
        _customerQueue[_customerQueue.Length - 1] = null;

        agent.IsWaitingInQueue = false;
        agent.QueueTransform = null;
        agent.QueueIndex = -1;
    }


    public bool HasRoomToQueue()
    {
        for (int i = 0; i < _customerQueue.Length; i++)
        {
            if (_customerQueue[i] == null)
            {
                return true;
            }
        }
        return false;
    }


    public Transform GetQueuePosition(AgentQueuingBehaviour agent)
    {
        for (int i = 0; i < _customerQueue.Length; i++)
        {
            if (_customerQueue[i] == null)
            {
                return WaitingPoints[i];
            }
        }

        Debug.Log("not found");
        return WaitingPoints[0];
        return default;
    }

}
