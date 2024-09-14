using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : MonoBehaviour
{
  
    // Start is called before the first frame update
    
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            //GameManager.instance.CurrentRage += 20;

        }
        if (other.tag == "Father")
        {
            Destroy(gameObject);
        }

        //explosion();
        //Destroy(gameObject);
    }
    private void Start()
    {
        
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        //Vector3 dir = transform.forward;
        //transform.position += dir * 20f * Time.deltaTime;
    }
}
