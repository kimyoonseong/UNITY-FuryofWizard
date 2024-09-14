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
                if (cols[i].tag == "Player")//�����ȿ� ������
                {
                    //Debug.Log("Physics Enemy : Target found");
                    target = cols[i].gameObject.transform;
                    break;
                }
                else//�����ȿ� ������
                {
                    target = null;
                }

            }
        }
        if (target != null)//�÷��̾ �����ȿ� ������
        {
            Instantiate(skeleton, transform.position, transform.rotation);

        }
        else//�÷��̾ �����ȿ� ������,
        {
            
        }

    }
    

    IEnumerator Start1()
    {// yield������ϱ�����IEnumeratortype����return
        while (true)
        {
            Instantiate(skeleton, transform.position, transform.rotation);
            // �÷��ǵ����͸��ϳ���return �Ĵ���������ġ���(Unity��coroutine ����)
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
