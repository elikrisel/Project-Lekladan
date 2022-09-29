using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    [RequireComponent(typeof(Rigidbody))]
    public class PickableItem : MonoBehaviour
    {

        private Rigidbody rb;
        public Rigidbody Rb => rb;

        public static bool isDestroyed = false;

        
        void Awake()
        {
            
            rb = GetComponent<Rigidbody>();
            

        }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Saboteur"))
        {
       
            SaboteurShoot.currentBall++;
            ScoreManager.instance.AddPlayerScore();
                
            SoundManager.Instance.Play(SettingHolder.Instance.Score);

            isDestroyed = true;
            Destroy(this.gameObject);
                                
        }
    }
}
    


