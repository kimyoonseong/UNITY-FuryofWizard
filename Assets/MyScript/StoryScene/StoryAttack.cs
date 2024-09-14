using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryAttack : MonoBehaviour
{
  
    private void Start()
    {
    
    }


    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Father")
        {
            Destroy(gameObject);
             
           

            
        }

    
    }
    private void Update()
    {
        
    }
}
