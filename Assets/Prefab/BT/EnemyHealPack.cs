using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealPack : MonoBehaviour
{
    public GameObject Particle;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 50f * Time.deltaTime));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GetComponent<MeshRenderer>().enabled = false;
            //DefParticle.SetActive(false);
            GameManager.instance.BTWizardHP += 50;
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
