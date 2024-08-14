using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;
using UnityEngine;

public class EatPizzaAction : ActionBase<EatPizzaAction.Data>
{
    public static System.Action OnAgentEatCompleted;
    public override void Created()
    {

    }

    public override void Start(IMonoAgent agent, Data data)
    {
        var inventory = agent.GetComponent<InventoryBehaviour>();
        if (inventory == null) return;

        data.Pizza = inventory.Pizza;
        data.Hunger = agent.GetComponent<HungerBehaviour>();
        agent.GetComponent<AnimationBehaviour>().IsEating = true;
        //agent.transform.rotation = Quaternion.Euler(0, 260, 0);
        agent.GetComponent<AgentSeatBehaviour>().Table.UpdateAgentSeatTransform(agent.GetComponent<AgentSeatBehaviour>());
    }


    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        if (data.Pizza == null || data.Hunger == null)
        {
            agent.GetComponent<AnimationBehaviour>().IsEating = false;
            return ActionRunState.Stop;
        }
            

        var eatNutrition = context.DeltaTime * 10f;
        data.Pizza.NutritionValue -= eatNutrition;
        data.Hunger.Hunger -= eatNutrition * 1;

        if (data.Pizza.NutritionValue <= 0)
        {
            GameObject.Destroy(data.Pizza.gameObject);
            //data.Pizza.gameObject.SetActive(false);
        
            agent.GetComponent<AgentBrain>().ActiveWanderGoal();
        }

        return ActionRunState.Continue;
    }


    public override void End(IMonoAgent agent, Data data)
    {
        agent.GetComponent<AnimationBehaviour>().IsEating = false;
        agent.GetComponent<AgentSeatBehaviour>().Standup();
        agent.GetComponent<AgentSeatBehaviour>().Table = null;

        OnAgentEatCompleted?.Invoke();
    }




    public class Data : IActionData
    {
        public ITarget Target { get; set; }
        public PizzaBehaviour Pizza { get; set; }
        public HungerBehaviour Hunger { get; set; }
        public TableBehaviour Table { get; set; }
    }
}
