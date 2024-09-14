using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class DefaultAttack : MonoBehaviour
{   
    public int damage;
    public GameObject expParticle;

    public GameObject Defaultattack1;
    public GameObject Defaultattack2;
    public GameObject Defaultattack3;
    public GameObject Defaultattack4;
    public GameObject Defaultattack5;

    RageSlider rage1;//레이지 슬라이더 선언
    private void OnCollisionEnter(Collision collision)
    {   
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //GameObject.Find("UIController").GetComponent<RageSlider>().currentValue +=20;
            GameManager.instance.CurrentRage += 15;
            GameManager.instance.BTWizardHP -= 10;
        }
        
       explosion();
        Destroy(gameObject, 0.3f);
    }

    //파티클 터지는것 20221013
    void explosion()
    {
        expParticle.SetActive(true);
        //GetComponent<MeshRenderer>().enabled = false;
        Destroy(Defaultattack1);
        Destroy(Defaultattack2);
        Destroy(Defaultattack3);
        Destroy(Defaultattack4);
        Destroy(Defaultattack5);
        GetComponent<SphereCollider>().enabled = false;
        //Destroy(gameObject);
        Invoke("destObj", 0.5f);
    }
        private void Start()
    {
        damage = 10;
        Destroy(gameObject,5f);
    }
    void desObj()
    {
        Destroy(gameObject);
    }
}
