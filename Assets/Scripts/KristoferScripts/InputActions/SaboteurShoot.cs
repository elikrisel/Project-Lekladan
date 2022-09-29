using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Serialization;



    public class SaboteurShoot : MonoBehaviour
    {
        [Header("Input System")] 
        private InputActionMap _playerInput;
        private InputActionAsset _inputAsset;
        private InputAction _interact;

        [Header("Ball Prefab")] 
        [SerializeField] private Rigidbody ballPrefab;
        [Header("Mr Bucket Art Prefab")]
        [SerializeField] private Transform artPrefab;
        
        
        [Header("Shoot Force")] 
        [Range(1, 200)] [SerializeField] private float shootForce;

        [Header("Cooldown Time on Shoot")]
        [Range(1,5)] 
        [SerializeField] private float cooldownTime;
        
        private float nextFireTime;
        public GameObject ballVisual;

        
        
        [Header("Ammo Container UI")]
        [SerializeField] private GameObject imageContainer;

        
        
        [Header("Conditions")] 
        public bool canShoot;

        public static int currentBall;

        private bool CanFire => Time.time > nextFireTime;

        void Awake()
        {
            
            _inputAsset = this.GetComponent<PlayerInput>().actions;
            _playerInput = _inputAsset.FindActionMap("Player");
            

        }

        void Start()
        {
            canShoot = false;
            ballVisual.SetActive(false);
            
            imageContainer = GameObject.Find("Ammo");
            imageContainer.SetActive(false);
        }

        
        void Update()
        {
            
            if (currentBall > 0)
            {
                ballVisual.gameObject.SetActive(true);
                imageContainer.SetActive(true);
                
                
                
            }
        }

        private void OnEnable()
        {
            _playerInput.FindAction("Interact").performed += OnShoot;
        }
        
        private void OnDisable()
        {
            _playerInput.Disable();   
        }
        
        private void OnShoot(InputAction.CallbackContext ctx)
        {
            //Debug.Log("Interact pressed");
            if (PickableItem.isDestroyed)
            {
                
                canShoot = true;
                if (canShoot && CanFire)
                {
                    
                    Shooting();    
                }
                
                
            }
            
        }
        
        private void Shooting()
        {
            
            nextFireTime = Time.time + cooldownTime;
            
            var ballTransform = artPrefab.transform;
            Rigidbody ballClone = Instantiate(ballPrefab, ballTransform.position, ballTransform.rotation);
            ballClone.velocity = artPrefab.forward * shootForce;
            
            
            
            
            currentBall--;
            
            
            
            //When the Saboteur has no ball
            if (currentBall <= 0)
            {
                
                PickableItem.isDestroyed = false;
                ballVisual.SetActive(false);
                imageContainer.SetActive(false);
                canShoot = false;
                
            }
            
        }


        

            

        }
        
        
   

    
    

