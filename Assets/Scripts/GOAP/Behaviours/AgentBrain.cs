using CrashKonijn.Goap.Behaviours;
using UnityEngine;

public class AgentBrain : MonoBehaviour
{
    private AgentBehaviour _agent;
    private HungerBehaviour _hunger;

    private void Awake()
    {
        _agent = GetComponent<AgentBehaviour>();
        _hunger = GetComponent<HungerBehaviour>();
    }

    private void Start()
    {
        _agent.SetGoal<WanderGoal>(false);
    }

    private void Update()
    {
        if(this._hunger.Hunger > 50)
        {
            this._agent.SetGoal<FixHungerGoal>(false);
            return;
        }

        //if (this._hunger.Hunger < -100)
        //{
        //    this._agent.SetGoal<WanderGoal>(true);
        //}
    }

    public void ActiveWanderGoal()
    {
        this._agent.SetGoal<WanderGoal>(true);
    }
}