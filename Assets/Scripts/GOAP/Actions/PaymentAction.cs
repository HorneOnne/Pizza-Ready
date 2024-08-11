using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;

public class PaymentAction : ActionBase<PaymentAction.Data>
{
    public override void Created()
    {

    }

    public override void Start(IMonoAgent agent, Data data)
    {
     
    }


    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
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