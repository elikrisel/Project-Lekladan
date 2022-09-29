using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] private int _playerSpeed;
    [SerializeField] private int _rotationSpeed;
    [SerializeField] private int _speedDampen;
    [SerializeField] private float _maxPlayerSpeedValue;
    [SerializeField] private float _slowSpeed;
    private float _maxPlayerSpeed;


    [Header("Components")]
    private Rigidbody _playerRB;
    [SerializeField] public Transform _artPrefab;
    [SerializeField] private bool _isBucket;
    [SerializeField] private Animator _animator;

    [Header("Input System")]
    private InputActionMap _playerInput;
    private InputActionAsset _inputAsset;
    private InputAction _move;

    public Vector3 Direction;
    public bool _isSlowed;


    void Awake()
    {
        _playerRB = this.GetComponent<Rigidbody>();

        _inputAsset = this.GetComponent<PlayerInput>().actions;
        _playerInput = _inputAsset.FindActionMap("Player");
    }

    private void OnEnable()
    {
        _move = _playerInput.FindAction("Move");
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        Vector2 moveInput = _move.ReadValue<Vector2>();
        Direction = new Vector3(moveInput.x, 0, moveInput.y);

        if (_isSlowed == true)
        {
            _maxPlayerSpeed = _slowSpeed;
        }
        else _maxPlayerSpeed = _maxPlayerSpeedValue;

        _playerRB.AddForce(Direction * _playerSpeed * Time.fixedDeltaTime, ForceMode.Acceleration);

        _animator.SetBool("isWalking", Direction.magnitude > 0);

        //Determines max speed to the player
        if (_playerRB.velocity.magnitude > _maxPlayerSpeed)
        {
            _playerRB.velocity = _playerRB.velocity.normalized * _maxPlayerSpeed;
        }

        //Less gliding when letting go of controlls
        if(moveInput == Vector2.zero)
        {
            _playerRB.AddForce(new Vector3(_playerRB.velocity.x,0,_playerRB.velocity.z) * -_speedDampen);
        }

        PlayerRotation();
    }

    private void PlayerRotation()
    {
        //Turn in direction of movement
        if (Direction != Vector3.zero)
        {
            if (_isBucket)
                _artPrefab.rotation = Quaternion.Slerp(_artPrefab.rotation, Quaternion.LookRotation(Direction), Time.fixedDeltaTime * _rotationSpeed);
            else
                _artPrefab.rotation = Quaternion.Slerp(_artPrefab.rotation, Quaternion.LookRotation(-Direction), Time.fixedDeltaTime * _rotationSpeed);
        }
    }
}
