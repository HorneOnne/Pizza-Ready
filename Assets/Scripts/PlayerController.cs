using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputHandler _input;
    private Animator _anim;
    [SerializeField] private Transform _model;
    private Rigidbody _rb;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector3 _moveDirection;
    private Vector3 _cameraIsometricRot = new Vector3(0, 45, 0);

    public Vector3 CurrentVel;

    // Animation
    private bool _hasAnimator;
    // animation IDs
    private int _animIDVelocity;




    #region Properties
    public Rigidbody Rigidbody { get => _rb; }
    public float MoveSpeed { get => _moveSpeed; }
    #endregion


    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        _hasAnimator = _anim != null;
        _rb = GetComponent<Rigidbody>();
    }


    private void Start()
    {
        _input = InputHandler.Instance;
        AssignAnimationIDs();
    }



    // Rotation angle (positive for right, negative for left)
    public float rotationAngle = 45f;

    Vector3 RotateVectorAroundY(Vector3 vector, float angle)
    {
        // Create a quaternion for rotation around Y-axis
        Quaternion rotationQuaternion = Quaternion.Euler(0f, angle * UnityEngine.Time.deltaTime, 0f);

        // Rotate the vector using the quaternion
        Vector3 rotatedVector = rotationQuaternion * vector;

        return rotatedVector;
    }

    private BoxCollider2D _box2D;
    private void Update()
    {
        CurrentVel = _rb.velocity;


        //if (Simulate)
        //{
        //    _entity.Simulate = Simulate;
        //}



   
        UpdateRotation(ToGameDirection(new Vector3(_input.Move.x, 0, _input.Move.y)));





        // Animation
        // =========
        if (_hasAnimator)
        {
            _anim.SetFloat(_animIDVelocity, _input.Move.magnitude);
        }
    }

    private void FixedUpdate()
    {
        UpdatePosition(_moveSpeed);
    }



    private void UpdatePosition(float speed)
    {
        if (_input.Move != Vector2.zero)// && _input.Fire1 == false)
        {
            _moveDirection = new Vector3(_input.Move.x * speed, 0, _input.Move.y * speed);
            Vector3 _rotMoveDir = ToGameDirection(_moveDirection);
            _rb.velocity = new Vector3(_rotMoveDir.x, _rb.velocity.y, _rotMoveDir.z);

            _rb.AddForce(new Vector3(_rotMoveDir.x, _rb.velocity.y, _rotMoveDir.z), ForceMode.Force);

            //_entity.SetVelocity(new Vector3(_rotMoveDir.x, _entity.Velocity.y, _rotMoveDir.z));
        }
        else
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
            //_entity.SetVelocity(new Vector3(0, _entity.Velocity.y, 0));
        }
    }


    private Collider[] _groundHit = new Collider[1];


    private void UpdateRotation(Vector3 gameDirection)
    {
        RotateTowardMoveDirection(gameDirection);
    }


    private void RotateTowardMoveDirection(Vector3 direction)
    {
        if (direction.sqrMagnitude >= 0.1f)
        {
            // Calculate the rotation to look towards the move direction
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);

            // Apply the rotation to the character
            _model.rotation = Quaternion.Slerp(_model.rotation, lookRotation, UnityEngine.Time.deltaTime * 10f);
        }
    }

    private void AssignAnimationIDs()
    {
        _animIDVelocity = Animator.StringToHash("Velocity");

    }




    public Vector3 ToGameDirection(Vector3 worldDirection)
    {
        return Matrix4x4.Rotate(Quaternion.Euler(new Vector3(0, Camera.main.transform.eulerAngles.y, 0))).MultiplyPoint3x4(worldDirection);
    }
}
