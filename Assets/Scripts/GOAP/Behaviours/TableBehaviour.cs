using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class TableBehaviour : MonoBehaviour
{
    private TableCollection _tableCollection;
    [SerializeField] private AgentSeatBehaviour[] _agents;
    public int EmptySeatCount = 2;
    public List<Transform> ChairsPosition;

    private void Awake()
    {
        _tableCollection = GameObject.FindObjectOfType<TableCollection>();
        transform.localScale = Vector3.zero;
        transform.DOScale(1.0f, 0.35f).SetEase(Ease.InOutSine);


        // initial null agents
        EmptySeatCount = ChairsPosition.Count;
        _agents = new AgentSeatBehaviour[EmptySeatCount];
        for (int i = 0; i < _agents.Length; i++)
        {
            _agents[i] = null;
        }


    }


    private void OnEnable()
    {
        _tableCollection.Add(this);
    }

    private void OnDisable()
    {
        _tableCollection.Remove(this);
    }


    public bool HasSeat(AgentSeatBehaviour agent)
    {
        for (int i = 0; i < _agents.Length; i++)
        {
            if (_agents[i] == agent)
                return true;
        }
        return EmptySeatCount > 0;
    }


    public void SitDown(AgentSeatBehaviour agent)
    {
        EmptySeatCount--;

        for (int i = 0; i < _agents.Length; i++)
        {
            if (_agents[i] == null)
            {
                _agents[i] = agent;
                return;
            }
        }
    }

    public void StandUp(AgentSeatBehaviour agent)
    {
        EmptySeatCount++;
        for (int i = 0; i < _agents.Length; i++)
        {
            if (_agents[i] == agent)
            {
                _agents[i] = null;
                return;
            }
        }

    }

    public Transform GetSeat(AgentSeatBehaviour agent)
    {
        Debug.Log("Get seat");
        //return ChairsPosition[0].transform;

        
        for (int i = 0; i < _agents.Length; i++)
        {
            if (_agents[i] == agent)
            {               
                return ChairsPosition[i].transform;
            }
        }
        return null;
    }

    public void UpdateAgentSeatTransform(AgentSeatBehaviour agent)
    {
        if(agent == _agents[0])
        {
            agent.transform.rotation = Quaternion.Euler(0, 80, 0);
          
        }
        else if(agent == _agents[1])
        {
            agent.transform.rotation = Quaternion.Euler(0, 260, 0);
        }
    }
}
