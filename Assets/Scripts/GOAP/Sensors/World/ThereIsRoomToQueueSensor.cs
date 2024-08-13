using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;
using UnityEngine;
using CrashKonijn.Goap.Interfaces;

public class ThereIsRoomToQueueSensor : GlobalWorldSensorBase
{
    private WaitingLane _waitingLane;

    public override void Created()
    {
        _waitingLane = GameObject.FindObjectOfType<WaitingLane>();
    }

    public override SenseValue Sense()
    {
        Debug.Log($"ThereIsRoomToQueueSensor: {_waitingLane.HasRoomToQueue()}");
        return _waitingLane.HasRoomToQueue();
    }
}