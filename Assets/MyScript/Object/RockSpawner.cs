using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject RollingRock;
    public float interval;
    public float range = 3.0f;
    // Start is called before the first frame update
    
    IEnumerator Start()
    {// yield을사용하기위해IEnumeratortype으로return
        while (true)
        {
            transform.position = new Vector3(transform.position.x,
                                                 transform.position.y, Random.Range(-30, -23));
            Instantiate(RollingRock, transform.position, transform.rotation);
            // 컬렉션데이터를하나씩return 후다음실행위치기억(Unity의coroutine 참조)
            yield return new WaitForSeconds(interval);
        }
    }
    
}
