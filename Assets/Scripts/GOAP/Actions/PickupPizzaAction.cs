using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;
using UnityEngine;

public class PickupPizzaAction : ActionBase<PickupPizzaAction.Data>
{
    private WaitingLane _waitingLane;
    private TableCollection _tableCollection;

    public override void Created()
    {
        _waitingLane = GameObject.FindObjectOfType<WaitingLane>();
        _tableCollection = GameObject.FindObjectOfType<TableCollection>();  
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


        var servingCounter = transformTarget.Transform.GetComponentInParent<CounterBehaviour>();
        var pizza = servingCounter.ServePizza();
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
        Debug.Log($"End pickup pizza action: {agent.transform.name}");
        if (agent.GetComponent<AgentSeatBehaviour>().IsSitDown) return;
        for (int i = 0; i < _tableCollection.Tables.Count; i++)
        {
            if (_tableCollection.Tables[i].HasSeat(agent.GetComponent<AgentSeatBehaviour>()))
            {
                agent.GetComponent<AgentSeatBehaviour>().Sitdown(_tableCollection.Tables[i]);
                return;
                //_tables[i].SitDown(agent.GetComponent<AgentSeatBehaviour>());
            }
        }
    }




    public class Data : IActionData
    {
        public ITarget Target { get; set; }
    }
}
