using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRock : MonoBehaviour
{
    public GameObject rock;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rock.SetActive(true);
            Destroy(gameObject, 3f);
        }
        
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
