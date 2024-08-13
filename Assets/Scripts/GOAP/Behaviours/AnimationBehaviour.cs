using UnityEngine;
using CrashKonijn.Goap.Behaviours;
using UnityEngine.AI;

public class AnimationBehaviour : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navmeshAgent;
    private AgentBehaviour _agent;
    private static readonly int Velocity = Animator.StringToHash("Velocity");

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        _navmeshAgent = GetComponent<NavMeshAgent>();   
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        //_anim.SetFloat(_animIDVelocity, _input.Move.magnitude);
        this._anim.SetFloat(Velocity, _navmeshAgent.velocity.magnitude);
    }
}