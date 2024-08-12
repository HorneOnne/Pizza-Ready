using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;
using UnityEngine;

public class EatPizzaAction : ActionBase<EatPizzaAction.Data>
{
    private PizzaCollection _pizzaCollection;
    public override void Created()
    {

    }

    public override void Start(IMonoAgent agent, Data data)
    {
        _pizzaCollection = GameObject.FindObjectOfType<PizzaCollection>();
        var inventory = agent.GetComponent<InventoryBehaviour>();
        if (inventory == null) return;

        data.Pizza = inventory.Pizza;
        data.Hunger = agent.GetComponent<HungerBehaviour>();
    }


    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        Debug.Log("Eat pizza action");
        if (data.Pizza == null || data.Hunger == null)
            return ActionRunState.Stop;

        var eatNutrition = context.DeltaTime * 30f;

        data.Pizza.NutritionValue -= eatNutrition;
        data.Hunger.Hunger -= eatNutrition * 10;

        if (data.Pizza.NutritionValue <= 0)
        {
            _pizzaCollection.Remove(data.Pizza);
            GameObject.Destroy(data.Pizza.gameObject);
            //data.Pizza.gameObject.SetActive(false);
            agent.GetComponent<AgentBrain>().ActiveWanderGoal();
        }


        return ActionRunState.Continue;
    }


    public override void End(IMonoAgent agent, Data data)
    {

    }




    public class Data : IActionData
    {
        public ITarget Target { get; set; }
        public PizzaBehaviour Pizza { get; set; }
        public HungerBehaviour Hunger { get; set; }
        public TableBehaviour Table { get; set; }
    }
}
