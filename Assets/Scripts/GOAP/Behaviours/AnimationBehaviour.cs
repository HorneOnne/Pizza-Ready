using UnityEngine;
using CrashKonijn.Goap.Behaviours;
using UnityEngine.AI;

public class AnimationBehaviour : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _navmeshAgent;
    private AgentBehaviour _agent;
    private static readonly int Velocity = Animator.StringToHash("Velocity");
    private static readonly int SeatAndEat = Animator.StringToHash("SeatAndEat");

    [field: SerializeField] public bool IsEating { get; set; }

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
        this._anim.SetFloat(Velocity, _navmeshAgent.velocity.magnitude);

        this._anim.SetBool(SeatAndEat, IsEating);
    }
}