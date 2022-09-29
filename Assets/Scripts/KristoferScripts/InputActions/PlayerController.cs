using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody rb;
    
    
    [Header("Unity Input System")]
    private PlayerInputActions playerInputActions;
    
    [Header("Movement Variables")]
    private Vector2 movementInput;
    private Vector3 currentMovement;
    private bool movementPressed;
    
    [SerializeField] private float movementSpeed = 1f;

    
   
        
     
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        playerInputActions.Player.Movement.canceled += ctx => movementInput = Vector2.zero;

    }

    void OnEnable()
    {
            
                
        playerInputActions.Player.Enable();

        
    }

    void OnDisable()
    {
        
        playerInputActions.Player.Disable();

    }

    void Update()
    {
        currentMovement = new Vector2(movementInput.x, movementInput.y);
        
    }
    
    void FixedUpdate()
    {

        OnMove(currentMovement);
        HandleRotation();
    }

    void OnMove(Vector3 forceDirection)
    {
        forceDirection = new Vector3(movementInput.x * movementSpeed * Time.fixedDeltaTime,0,movementInput.y * movementSpeed * Time.fixedDeltaTime);
        rb.MovePosition(transform.position + forceDirection);

    }

    void HandleRotation()
    {
        Vector3 currentPosition = transform.position;
        
        Vector3 newPosition = new Vector3(movementInput.x,0,movementInput.y);
        Vector3 lookAtPosition = currentPosition + newPosition;
        transform.LookAt(lookAtPosition);


    }
  
}
