using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPack : MonoBehaviour
{
    //public GameObject DefParticle;
    public GameObject Particle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 50f * Time.deltaTime));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<MeshRenderer>().enabled = false;
            //DefParticle.SetActive(false);
            GameManager.instance.PlayerCurrentHp += 30;
            explosion();
            Destroy(gameObject, 0.5f);
        }

    }

    void explosion()
    {
        Particle.SetActive(true);

        GetComponent<BoxCollider>().enabled = false;


    }
}
