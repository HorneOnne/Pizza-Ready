using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;
using UnityEngine;
public class WaitToTakePizzaAction : ActionBase<WaitToTakePizzaAction.Data>
{
    public override void Created()
    {
       
    }
    public override void Start(IMonoAgent agent, Data data)
    {

    }

    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        var queueBehaviour = agent.GetComponent<AgentQueuingBehaviour>();
        if(queueBehaviour == null)
            return ActionRunState.Stop;

        if(queueBehaviour.QueueIndex == 0)
        {
            Debug.Log("Stop");
            return ActionRunState.Stop;
        }

        Debug.Log("Continue");
        return ActionRunState.Continue;
    }

    public override void End(IMonoAgent agent, Data data)
    {
      
    }

  
    public class Data : IActionData
    {
        public ITarget Target { get; set; }
    }
}