using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingRock : MonoBehaviour
{
    [Tooltip("\"Fractured\" is the object that this will break into")]
    public GameObject fractured;


    private void OnCollisionEnter(Collision collision)
    {

        //FractureObject();
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FractureObject();

        }
        

    }
    public void FractureObject()
    {
        GameObject obj = Instantiate(fractured, transform.position, transform.rotation); //Spawn in the broken version
        Destroy(gameObject); //Destroy the object to stop it getting in the way
        Destroy(obj, 0.65f);

    }
    private void Start()
    {
        Destroy(gameObject, 8f);
    }
}
