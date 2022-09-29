using UnityEngine;
using UnityEngine.InputSystem;

public class JumpScript : MonoBehaviour
{
    [Header("Jump Values")]
    [SerializeField] private int _playerJumpHeight;
    [SerializeField] private int _playerJumpSpeed;
    [SerializeField] private int _gravityForce;
    [SerializeField] private float _cooldownTimer;
    private float _cooldown;

    [Header("Components")]
    private Rigidbody _playerRB;
    [SerializeField] private Animator _animator;

    [Header("Input System")]
    private InputActionMap _playerInput;
    private InputActionAsset _inputAsset;

    void Awake()
    {
        _inputAsset = this.GetComponent<PlayerInput>().actions;
        _playerInput = _inputAsset.FindActionMap("Player");

        _playerRB = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _playerInput.FindAction("Jump").performed += OnJump;
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }


    private void FixedUpdate()
    {       
        PlayerGravity();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (Time.time > _cooldown && this.gameObject.GetComponent<GrounCheck>()._onGround == true)
        {
            _cooldown = Time.time + _cooldownTimer;
            PlayerJump();
            _animator.Play("Jump");
            SoundManager.Instance.Play(SettingHolder.Instance.Jump);
        }
    }

    private void PlayerJump()
    {
        Vector3 Rotation = this.GetComponent<MovementScript>().Direction;
        if(Rotation != Vector3.zero)
        {
        _playerRB.AddForce(Rotation * _playerJumpSpeed, ForceMode.VelocityChange);
        _playerRB.AddForce(Vector3.up * _playerJumpHeight, ForceMode.Impulse);
        }

        else _playerRB.AddForce(Vector3.up * _playerJumpHeight * 0.2f, ForceMode.Impulse);

    }

    private void PlayerGravity()
    {
        if(this.gameObject.GetComponent<GrounCheck>()._onGround == false)
        _playerRB.AddForce(Vector3.down * _gravityForce * _playerRB.mass);
    }
}
