using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryKing : MonoBehaviour
{
    public GameObject Bullet;
    private Animator Kinganim;
    public Transform Root;
    public bool isStop;
    // Start is called before the first frame update
    void Start()
    {
        isStop = true;
        

    }
    
    public virtual void Awake()
    {        
        Kinganim = GetComponentInChildren<Animator>();
        
    }
    IEnumerator KingAttack()
    {
        //yield return new WaitForSeconds(1f);
        Kinganim.SetBool("isKingAttack", true);
        yield return new WaitForSeconds(1.5f);
        
        GameObject instantBullet = Instantiate(Bullet, Root.transform.position, transform.rotation);
        Rigidbody rigidBullet = instantBullet.GetComponent<Rigidbody>();
        rigidBullet.velocity = transform.forward * 11;

        yield return new WaitForSeconds(1f);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.StoryFinish&& isStop)
        {
            StartCoroutine(KingAttack());
            isStop = false;
            //GameManager.instance.StoryFinish = false;
        }
    }
}
