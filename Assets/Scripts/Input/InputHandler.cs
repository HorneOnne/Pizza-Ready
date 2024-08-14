using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }
    public event System.Action OnRotateDetected;
    public event System.Action OnToggleInventory;

    private PlayerInput _playerInput;
    private FixedJoystick _joyStick;

    [Header("Character Input Values")]
    public Vector2 Move;

    private void Awake()
    {
        _joyStick = FindObjectOfType<FixedJoystick>();
        Instance = this;
        _playerInput = new PlayerInput();
      
        _playerInput.Player.Move.started += x => { Move = x.ReadValue<Vector2>().normalized; };
        _playerInput.Player.Move.performed += x => { Move = x.ReadValue<Vector2>().normalized; };
        _playerInput.Player.Move.canceled += x => { Move = x.ReadValue<Vector2>().normalized; };
    }


    private void OnDestroy()
    {

    }


    #region Enable / Disable
    private void OnEnable()
    {
        _playerInput.Enable();

    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    #endregion


    private void Start()
    {
        ActivePlayerMap();
    }

    private void Update()
    {
        Move = _joyStick.Direction;
    }

    public void ActivePlayerMap()
    {
        _playerInput.UI.Disable();
        _playerInput.Player.Enable();
    }
    public void ActiveUIMap()
    {
        _playerInput.Player.Disable();
        _playerInput.UI.Enable();
    }

    public bool IsPointerOverUIElement()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}