using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Skeleton : Enemy
{
    public bool SkeletonIschase;
    //20221102 ���ݱ���
    public BoxCollider meleeArea;
    public bool isAttack;
    public override void Start()
    {
        
        maxHealth = 20;
        curHealth = 20;
        target = GameObject.Find("Player").transform;
        nav.SetDestination(target.position);
        anim.SetBool("isWalk", true);
        Invoke("ChaseStart", 0.5f);
    }
    public override void Awake()
    {
        base.Awake();     
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DefaultAttack")
        {
            DefaultAttack bullet = other.GetComponent<DefaultAttack>();
            curHealth -= bullet.damage;
            StartCoroutine(Damaged());


        }
        //20221012 �ʻ�� ������
        if (other.tag == "SpecialAttack")
        {
            SpecialMove EnergyWave = other.GetComponent<SpecialMove>();       //SpecialMove ��ũ��Ʈ���� Specialmove ������Ʈ ��������.
            curHealth -= EnergyWave.Specialdamage;

            StartCoroutine(Damaged());
        }
    }

    //20221006 ������ �ִϸ��̼�, ��������fix

    IEnumerator Damaged()
    {
        isHit = true;
        nav.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.1f);

        if (curHealth > 0)
        {
            SkeletonIschase = false;
            anim.SetTrigger("Hit");                                             
        }
        else if (curHealth <= 0)
        {
            transform.Find("collider").gameObject.SetActive(false);
            transform.Find("Attackcollider").gameObject.SetActive(false);
            anim.SetTrigger("Die");
            Destroy(gameObject, 0.8f);
            
            nav.isStopped = true;
            SkeletonIschase = false;
        }
        yield return new WaitForSeconds(0.8f);
        isHit = false;
        SkeletonIschase = true;
    }
    void ChaseStart()//20221102 ����
    {
        SkeletonIschase = true;
        anim.SetBool("isWalk", true);
    }
    public override void Update()
    {
        //if (Ischase)
        //{
        //    nav.SetDestination(target.position);
        //}
        if (nav.enabled)
        {
            nav.SetDestination(target.position);
            nav.isStopped = !SkeletonIschase;
        }
    }
    public override void FixedUpdate()
    {
        Targeting1();
    }
    void Targeting1()
    {
        float targetRadius = 0.5f;
        float targetRange = 1.2f;
        RaycastHit[] rayHits =
            Physics.SphereCastAll(transform.position,
                                   targetRadius,
                                   transform.forward,
                                   targetRange,
                                   LayerMask.GetMask("Player")
                                   );
        if(rayHits.Length>0 && !isAttack && curHealth > 0 && !isHit)//�������� �ƴϸ鼭 ���� �ȿ� ���Դ�
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        if (curHealth > 0)
        {
            SkeletonIschase = false;
            isAttack = true;
            anim.SetBool("isAttack", true);

            yield return new WaitForSeconds(0.8f);
            meleeArea.enabled = true;
            yield return new WaitForSeconds(0.5f);
            meleeArea.enabled = false;

            //yield return new WaitForSeconds(1f);
            SkeletonIschase = true;
            isAttack = false;
            anim.SetBool("isAttack", false);
        }
        
    }

}
