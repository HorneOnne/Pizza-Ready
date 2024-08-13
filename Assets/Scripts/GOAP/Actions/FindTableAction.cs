﻿using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;
using UnityEngine;

public class FindTableAction : ActionBase<FindTableAction.Data>
{
    public override void Created()
    {

    }

    public override void Start(IMonoAgent agent, Data data)
    {
        if (data.Target is not TransformTarget transformTarget)
            return;

        data.Table = transformTarget.Transform.GetComponent<TableBehaviour>();
        UnityEngine.Debug.Log(data.Table.gameObject.transform.position);
    }


    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        if (data.Table == null)
            return ActionRunState.Stop;

        if(data.Table.HasSeat())
        {
            var seat = agent.GetComponent<SeatBehaviour>();
            if (seat == null)
                return ActionRunState.Stop;

            seat.Sitdown(data.Table);
            return ActionRunState.Stop;
        }          
        else
            return ActionRunState.Continue;
    }


    public override void End(IMonoAgent agent, Data data)
    {

    }




    public class Data : IActionData
    {
        public ITarget Target { get; set; }
        public TableBehaviour Table { get; set; }
    }
}