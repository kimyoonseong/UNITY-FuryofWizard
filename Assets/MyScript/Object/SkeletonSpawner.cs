using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{
    public Transform target;
    public GameObject skeleton;
    public float interval;
    // Start is called before the first frame update
    public void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 3f);
    }
    public virtual void UpdateTarget()
    {

        Collider[] cols = Physics.OverlapSphere(transform.position, 23f);

        if (cols.Length > 0)
        {

            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].tag == "Player")//범위안에 있을때
                {
                    //Debug.Log("Physics Enemy : Target found");
                    target = cols[i].gameObject.transform;
                    break;
                }
                else//범위안에 없을때
                {
                    target = null;
                }

            }
        }
        if (target != null)//플레이어가 범위안에 있을때
        {
            Instantiate(skeleton, transform.position, transform.rotation);

        }
        else//플레이어가 범위안에 없을때,
        {
            
        }

    }
    

    IEnumerator Start1()
    {// yield을사용하기위해IEnumeratortype으로return
        while (true)
        {
            Instantiate(skeleton, transform.position, transform.rotation);
            // 컬렉션데이터를하나씩return 후다음실행위치기억(Unity의coroutine 참조)
            yield return new WaitForSeconds(interval);
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DefaultAttack")
        {
            Destroy(gameObject);
            

        }
        if (other.tag == "SpecialAttack")
        {
            Destroy(gameObject);
            

        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
