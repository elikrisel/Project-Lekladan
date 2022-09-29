using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.MeshOperations;


    public class Grabbing : MonoBehaviour
{
    [Header("Player Components")]
    [Tooltip("Empty Gameobject(BoxHolder) on Player with following transform: (0 ,0 , 1.5)")]
    [SerializeField]
    private Transform boxHolder;
    [SerializeField] private Transform _artPrefab;
    [SerializeField] private Animator _animator;

    [Tooltip("Empty GameObject(Grab Detect) on the player with following transform: (0 ,-0.5 , 0.5")] 
    [SerializeField] private Transform grabDetect;

    [Tooltip("Grabbable Layermask")] [SerializeField]
    private LayerMask layerMask;

    private Vector3 origin;
    

    //Calling pickable script from ball prefab
    private PickableItem pickup;

    [Header("Input System")] 
    private InputActionMap _playerInput;
    private InputActionAsset _inputAsset;
    private InputAction _interact;
    
    [Header("Grab Range")] [Range(1, 5)] 
    [SerializeField] private float grabRange;
    
    
    
    [Header("Conditions")] 

    public bool isGrabbed;
    

    [Header("Aim Assist")] 
    [SerializeField] private GameObject target;

    [SerializeField] private float assistForce;
    
    [SerializeField] private float upwardsForce;

    
    //States
    public enum State
    {
        Idle,
        Grabbing,
        Dead,
    };

    private State _state;

    public State state
    {
        get => _state;
        set
        {
            var newState = value;
            if (newState == State.Idle)
            {
                _playerInput.FindAction("Interact").performed -= OnAim;
                _playerInput.FindAction("Interact").performed += OnGrab;
            
            }
            else if (newState == State.Grabbing)
            {
            
                _playerInput.FindAction("Interact").performed -= OnGrab;
                _playerInput.FindAction("Interact").performed += OnAim;
            
            }
            else if (newState == State.Dead)
            {
        
                _playerInput.FindAction("Interact").performed -= OnGrab;
                _playerInput.FindAction("Interact").performed -= OnAim;

            }
            
            _state = newState;
        }
    }

    void Awake()
    {
        _inputAsset = this.GetComponent<PlayerInput>().actions;
        _playerInput = _inputAsset.FindActionMap("Player");
        state = State.Idle;

    }
    
    void Update()
    {   
        //Debug.Log("Current State:" + state);
        target = GameObject.Find("BallDestroyer");
        
        if (state == State.Grabbing)
            this.gameObject.GetComponent<MovementScript>()._isSlowed = true;
        else
            this.gameObject.GetComponent<MovementScript>()._isSlowed = false;

    }
    
    private void OnEnable()
    {
        _interact = _playerInput.FindAction("Interact");
    }
    
   

    void OnGrab(InputAction.CallbackContext callbackContext)
    {
        origin = grabDetect.transform.position;
        
        Collider[] ballColliders = Physics.OverlapSphere(origin, grabRange,layerMask,QueryTriggerInteraction.UseGlobal);
        foreach (Collider c in ballColliders)
        {
            var pickable = c.transform.GetComponent<PickableItem>();
            if (c != null && c.CompareTag("Grab"))
            {
                if (pickable)
                {
                    
                    ItemPickup(pickable);
                    state = State.Grabbing;
                    if (isGrabbed)
                    {
                        return;
                    }
                    
                    
                }
                
            }
        }


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
            
        Gizmos.DrawWireSphere(origin, grabRange);
    }

    

    void OnAim(InputAction.CallbackContext callbackContext)
    { 
        AimAssist(pickup);
    }
    
    
    void ItemPickup(PickableItem item)
    {   
        state = State.Grabbing;
        isGrabbed = true;
        pickup = item;
        item.Rb.gameObject.transform.parent = boxHolder;
        item.Rb.gameObject.transform.position = boxHolder.position;
        item.Rb.GetComponent<Collider>().enabled = false;
        item.Rb.isKinematic = true;
        
    }

    void AimAssist(PickableItem item)
    {
        item.Rb.isKinematic = false;
        item.Rb.transform.parent = null;
        isGrabbed = false;
        Vector3 direction = target.transform.position - item.Rb.position;
        direction.Normalize();
        
        item.Rb.GetComponent<Collider>().enabled = true;
        item.Rb.AddForce(Vector3.up * upwardsForce);
        item.Rb.AddForce(direction * assistForce);

        
        state = State.Idle;

        _animator.Play("Throw");
    }
    
   
}
            
            
            
       
        
      

  