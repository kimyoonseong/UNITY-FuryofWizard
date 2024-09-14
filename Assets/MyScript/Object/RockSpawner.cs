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
    {// yield������ϱ�����IEnumeratortype����return
        while (true)
        {
            transform.position = new Vector3(transform.position.x,
                                                 transform.position.y, Random.Range(-30, -23));
            Instantiate(RollingRock, transform.position, transform.rotation);
            // �÷��ǵ����͸��ϳ���return �Ĵ���������ġ���(Unity��coroutine ����)
            yield return new WaitForSeconds(interval);
        }
    }
    
}
