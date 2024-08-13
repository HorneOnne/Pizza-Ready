using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using System;
using UnityEngine;
using DG.Tweening;

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
        this._currentTarget = target;
        this._shouldMove = !inRange;
    }

    private void OnTargetOutOfRange(ITarget target)
    {
        this._shouldMove = true;
    }


    public void ChangeTarget(Vector3 position)
    {
        PositionTarget target = new PositionTarget(position);
        this._currentTarget = target;
        _shouldMove = true;
    }


    public void MoveTo(Vector3 position)
    {
        _currentTarget = null;
        //transform.DOMove(position, MoveSpeed * Time.deltaTime);
        StartCoroutine(MoveToTargetCoroutine(position));
    }

    private IEnumerator MoveToTargetCoroutine(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }


    private void OnDrawGizmos()
    {
        if (this._currentTarget == null) return;
        Gizmos.DrawLine(transform.position, this._currentTarget.Position);
    }
}
