using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;
using UnityEngine;

public class QueuingAction : ActionBase<QueuingAction.Data>
{
    public override void Created()
    {
       
    }

    public override void Start(IMonoAgent agent, Data data)
    {
        Debug.Log("QueuingAction start");
        data.WaitingLane = GameObject.FindObjectOfType<WaitingLane>();
        data.Timer = Random.Range(0.3f, 1f);
    }

 

    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        Debug.Log("Queue action");
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

        if (agent.GetComponent<AgentQueuingBehaviour>().IsWaitingInQueue)
        {
            if (agent.GetComponent<AgentQueuingBehaviour>().QueueIndex == 0)
            {
                Debug.Log($"{agent.name} Stop");
                return ActionRunState.Stop;
            }
        }


        //data.Timer -= context.DeltaTime;
        //if (data.Timer > 0)
        //    return ActionRunState.Continue;
        //return ActionRunState.Stop;

        return ActionRunState.Continue;
    }


    public override void End(IMonoAgent agent, Data data)
    {

    }

    public class Data : IActionData
    {
        public ITarget Target { get; set; }
        public WaitingLane WaitingLane { get; set; }
        public float Timer { get; set; }
    }
}