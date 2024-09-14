using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father : MonoBehaviour
{
    private Animator fatheranim;
    public GameObject explosion;
    // Start is called before the first frame update
    public virtual void Awake()
    {
        fatheranim = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "WeakAttack")
        {
            explosion.SetActive(true);
            fatheranim.SetBool("isDie", true);
        }

        //explosion();
        //Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
