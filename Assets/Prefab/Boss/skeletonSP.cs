using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonSP : MonoBehaviour
{
    public GameObject skeleton;
    public float interval;
    public float range = 3.0f;
    // Start is called before the first frame update
    public IEnumerator zz;

    public void Spaw()
    {
        transform.position = new Vector3(Random.Range(-10, 10),
                                                 transform.position.y, Random.Range(-20, 0));
        Instantiate(skeleton, transform.position, transform.rotation);
    }
    //void Start()
    //{
    //    zz = run();
    //}
    //public void StartCo()
    //{
    //    StartCoroutine(zz);
    //}
    //public void StopCo()
    //{
    //    StopCoroutine(zz);
    //}
    //IEnumerator run()
    //{
      
    //        transform.position = new Vector3(Random.Range(-10, 10),
    //                                             transform.position.y, Random.Range(-20, 0));
    //        Instantiate(skeleton, transform.position, transform.rotation);
    //        yield return new WaitForSeconds(interval);
        
    //}
    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
