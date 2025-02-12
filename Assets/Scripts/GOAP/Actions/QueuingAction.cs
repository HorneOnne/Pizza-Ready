﻿using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;
using UnityEngine;

public class QueuingAction : ActionBase<QueuingAction.Data>
{
    private TableCollection _tableCollection;
    private CounterBehaviour _counter;
    public override void Created()
    {
      
    }

    public override void Start(IMonoAgent agent, Data data)
    {
        Debug.Log("QueuingAction start");
        data.WaitingLane = GameObject.FindObjectOfType<WaitingLane>();
        data.Timer = Random.Range(0.3f, 1f);
        _tableCollection = GameObject.FindObjectOfType<TableCollection>();
        _counter = GameObject.FindObjectOfType<CounterBehaviour>();
    }

 

    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        if (data.WaitingLane == null)
            return ActionRunState.Stop;


        if(data.WaitingLane.HasRoomToQueue() && agent.GetComponent<AgentQueuingBehaviour>().IsWaitingInQueue == false)
        {
            var customer = agent.GetComponent<AgentQueuingBehaviour>();
            if(customer == null)
                return ActionRunState.Stop;

            data.WaitingLane.Join(customer);
            //return ActionRunState.Stop;
        }

        //if (agent.GetComponent<AgentQueuingBehaviour>().IsWaitingInQueue)
        //{
        //    if (agent.GetComponent<AgentQueuingBehaviour>().QueueIndex == 0 && HasSeat() && HasServedPizza())
        //    {              
        //        Debug.Log($"{agent.name} Stop");
        //        return ActionRunState.Stop;
        //    }
        //}
        if (agent.GetComponent<AgentQueuingBehaviour>().IsWaitingInQueue)
        {
            if (agent.GetComponent<AgentQueuingBehaviour>().QueueIndex == 0 && HasServedPizza())
            {
                bool hasSeat = false;
                for (int i = 0; i < _tableCollection.Tables.Count; i++)
                {
                    if (_tableCollection.Tables[i].HasSeat(agent.GetComponent<AgentSeatBehaviour>()))
                    {
                        hasSeat = true;
                        break;
                    }
                }
                if (hasSeat == false)
                {
                    return ActionRunState.Continue;
                }
                Debug.Log($"{agent.name} Stop");
                return ActionRunState.Stop;
            }
        }


        return ActionRunState.Continue;
    }


    public override void End(IMonoAgent agent, Data data)
    {
       
    }

    public bool HasSeat(AgentSeatBehaviour agent)
    {
        for(int i = 0; i < _tableCollection.Tables.Count; i++)
        {
            if (_tableCollection.Tables[i].HasSeat(agent))
            {
                return true;
            }
        }

        return false;
    }

    public bool HasServedPizza()
    {
        return _counter.ServingPizzas.Count > 0;
    }

    public class Data : IActionData
    {
        public ITarget Target { get; set; }
        public WaitingLane WaitingLane { get; set; }
        public float Timer { get; set; }
    }
}