using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject expParticle; 
    public GameObject expParticle2;
    // Start is called before the first frame update
   
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DefaultAttack")
        {
            GameManager.instance.WallHp -= GameManager.instance.DefaultAttackD;

        }
        if (GameManager.instance.WallHp == 0)
        {
            explosion();
            Destroy(gameObject, 2f);
        }

    }
    void explosion()
    {
        expParticle.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        expParticle2.SetActive(true);
        GetComponent<BoxCollider>().enabled = false;
        
    }
    
    
}
