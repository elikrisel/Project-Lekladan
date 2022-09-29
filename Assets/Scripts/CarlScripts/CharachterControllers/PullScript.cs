using UnityEngine;
using UnityEngine.InputSystem;

public class PullScript : MonoBehaviour
{
    //Pull other players as a ghost
    [Header("Pull Values")]
    [SerializeField] private float _pullRange;
    [SerializeField] private float _pullforce;

    [Header("Hold Timer")]
    [SerializeField] private float _holdTime;
    [SerializeField] private float _cooldownTime;
    private float _holdTimer;
    private float _cooldownTimer;

    [Header("Layermask")]
    [SerializeField] private LayerMask _layerMask;

    [Header("Input System")]
    private InputActionMap _playerInput;
    private InputActionAsset _inputAsset;
    private InputAction _interact;

    [Header("Components")]
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _inputAsset = this.GetComponent<PlayerInput>().actions;
        _playerInput = _inputAsset.FindActionMap("Player");

    }

    private void OnEnable()
    {
        _interact = _playerInput.FindAction("Interact");
    }

    private void OnDisable()
    {
        _interact.Disable();
    }

    private void Update()
    {
        PlayerPull();
        PullTimer();

        _animator.SetBool("isPulling", _interact.ReadValue<float>() > .1f && _holdTimer < _holdTime);
    }

    private void PlayerPull()
    {
        Collider[] ballColliders = Physics.OverlapSphere(transform.position, _pullRange, _layerMask, QueryTriggerInteraction.UseGlobal);
        foreach (Collider c in ballColliders)
        {
            if (c != null && c.CompareTag("Player"))
            {
                if (_interact.ReadValue<float>() > .1f && _holdTimer < _holdTime)
                {
                    _holdTimer += Time.deltaTime;
                    c.GetComponent<Rigidbody>().AddForce(this.gameObject.GetComponent<MovementScript>().Direction * _pullforce, ForceMode.Acceleration);

                    this.gameObject.GetComponent<MovementScript>()._isSlowed = true;
                    c.GetComponent<MovementScript>()._isSlowed = true;

                }
            }
        }
    }

    private void PullTimer()
    {
        if (_holdTimer > _holdTime)
        {
            _cooldownTimer += Time.deltaTime;
            if (_cooldownTimer > _cooldownTime)
            {
                _holdTimer = 0f;
                _cooldownTimer = 0f;
            }
        }
    }
}
