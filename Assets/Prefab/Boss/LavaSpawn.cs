using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSpawn : MonoBehaviour
{
    public GameObject Lava;
    //public float interval;
    //public float range = 3.0f;
    // Start is called before the first frame update
    public IEnumerator zz;

    public void Spaw()
    {
        transform.position = new Vector3(Random.Range(-10, 10),
                                                 0, Random.Range(-20, 0));
        Instantiate(Lava, transform.position, transform.rotation);
    }
}
