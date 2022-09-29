using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Serialization;


    public class Grab : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private GameObject ball;
        private Vector3 offset;
        private RaycastHit hit;
        [Header("Hands Transform")]
        [SerializeField] private Transform detectionRange;
        
        
        [Header("Variables")]
                
        public float grabRange = 2f;

        void Update()
        {
                Debug.Log(KeyCode.E + " pressed");
                PickingUpObject();

    
                
            
        }
        
        void PickingUpObject()
        {
        
        
            if (Input.GetKey(KeyCode.E))
            {
        
                Ray ray = new Ray(detectionRange.position, detectionRange.forward);
        
                if (Physics.Raycast(ray, out hit, grabRange, layerMask))
                {
                    Debug.DrawLine(ray.origin, hit.point, Color.red);
                    if (hit.collider != null)
                    {
                        if (hit.collider.GetComponent<Rigidbody>())
                        {
                            Debug.Log("This object has a rigidbody.");
                            if (ball == null)
                            {
                                detectionRange.transform.position = hit.point;
                                ball = hit.collider.gameObject;
                                offset = ball.transform.position - hit.point;
                            }
                        }
                    }
                }
                
                if (ball != null)
                {
                    ball.transform.position = detectionRange.transform.position + offset;
                }
            }
        
        }
        
        
    
        
    

    
    
}
