using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Kristofer.Experiment
{
    public class Spawner : MonoBehaviour
    {   
        
       
        
        private int ballCount = 0;
        [Header("Need to take measurement to decide spawn points")]
        public List<Vector3> ballPosition = new List<Vector3>();
        
        [SerializeField] private GameObject ballPrefab;

        void Start()
        {
            Invoke("BallSpawner",2f);
    
        }

        void BallSpawner()
        {
            while (ballCount < ballPosition.Count)
            {

                Instantiate(ballPrefab, ballPosition[ballCount], Quaternion.identity);
                ballCount++;
            }
    
        }
        
        
        
        
    }
        
        
        
}

    
    

