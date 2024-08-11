using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;

public class PickupPizzaAction : ActionBase<PickupPizzaAction.Data>
{
    public override void Created()
    {

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

        var pizza = transformTarget.Transform.GetComponent<PizzaBehaviour>();
        if (pizza == null)
            return ActionRunState.Stop;


        // prevent picking up same pizza
        if (pizza.IsPickUp)
            return ActionRunState.Stop;

        var inventory = agent.GetComponent<InventoryBehaviour>();
        if (inventory == null)
            return ActionRunState.Stop;

        inventory.Put(pizza);
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
