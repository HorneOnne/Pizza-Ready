using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;
using UnityEngine;

public class PickupPizzaAction : ActionBase<PickupPizzaAction.Data>
{
    private WaitingLane _waitingLane;
    public override void Created()
    {
        _waitingLane = GameObject.FindObjectOfType<WaitingLane>();
    }

    public override void Start(IMonoAgent agent, Data data)
    {

    }


    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        if (data.Target is not TransformTarget transformTarget)
            return ActionRunState.Stop;

        if (transformTarget.Transform == null)
            return ActionRunState.Stop;


        //var queue = transformTarget.Transform.GetComponent<AgentQueuingBehaviour>();
        //if (queue == null)
        //    return ActionRunState.Stop;
        //if(queue.QueueIndex != 0)
        //{
        //    Debug.Log("Stop");
        //    return ActionRunState.Stop;
        //}
        //else
        //{
        //    Debug.Log("Continue");
        //}

      

        var pizza = transformTarget.Transform.GetComponent<PizzaBehaviour>();
        if (pizza == null)
            return ActionRunState.Stop;


        // prevent picking up same pizza
        if (pizza.IsPickUp)
        {
            return ActionRunState.Stop;
        }
           

        var inventory = agent.GetComponent<InventoryBehaviour>();
        if (inventory == null)
            return ActionRunState.Stop;

        inventory.Put(pizza);
        _waitingLane.Out(agent.GetComponent<AgentQueuingBehaviour>());
        return ActionRunState.Stop;
    }


    public override void End(IMonoAgent agent, Data data)
    {

    }




    public class Data : IActionData
    {
        public ITarget Target { get; set; }
    }
}
