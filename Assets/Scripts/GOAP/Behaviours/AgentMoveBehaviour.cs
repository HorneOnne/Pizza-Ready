using UnityEngine;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using System;

public class AgentMoveBehaviour : MonoBehaviour
{
    private AgentBehaviour _agent;
    private ITarget _currentTarget;
    private bool _shouldMove;
    public float MoveSpeed = 10f;

    private void Awake()
    {
        this._agent = GetComponent<AgentBehaviour>();
    }

    private void OnEnable()
    {
        this._agent.Events.OnTargetInRange += OnTargetInRange;
        this._agent.Events.OnTargetChanged += OnTargetChanged;
        this._agent.Events.OnTargetOutOfRange += OnTargetOutOfRange;
    }
    private void OnDisable()
    {
        this._agent.Events.OnTargetInRange -= OnTargetInRange;
        this._agent.Events.OnTargetChanged -= OnTargetChanged;
        this._agent.Events.OnTargetOutOfRange -= OnTargetOutOfRange;
    }

    private void Update()
    {
        if (!this._shouldMove) return;
        if (_currentTarget == null) return;
        this.transform.position = Vector3.MoveTowards(this.transform.position, _currentTarget.Position, MoveSpeed * Time.deltaTime);
    }

    private void OnTargetInRange(ITarget target)
    {
        this._shouldMove = false;
    }

    private void OnTargetChanged(ITarget target, bool inRange)
    {
        Debug.Log($"Target change: {target.Position}");
        this._currentTarget = target;
        this._shouldMove = !inRange;
    }

    private void OnTargetOutOfRange(ITarget target)
    {
        this._shouldMove = true;
    }

    private void OnDrawGizmos()
    {
        if (this._currentTarget == null) return;
        Gizmos.DrawLine(transform.position, this._currentTarget.Position);
    }
}
