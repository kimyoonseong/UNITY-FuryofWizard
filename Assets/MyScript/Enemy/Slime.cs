using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        maxHealth = 10;
        curHealth = 10;
        InvokeRepeating("UpdateTarget", 0f, 0.25f);
    }
    public override void Awake()
    {
        base.Awake();


    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DefaultAttack")
        {
            nav.velocity = Vector3.zero;
            transform.Find("collider").gameObject.SetActive(false);
            transform.Find("Attackcollider").gameObject.SetActive(false);
            anim.SetTrigger("Die");
            Destroy(gameObject, 1.5f);
            isHit = true;
            nav.velocity = Vector3.zero;
            nav.isStopped = true;


        }
        //20221012 필살기 데미지
        if (other.tag == "SpecialAttack")
        {
            nav.velocity = Vector3.zero;
            transform.Find("collider").gameObject.SetActive(false);
            transform.Find("Attackcollider").gameObject.SetActive(false);
            anim.SetTrigger("Die");
            Destroy(gameObject, 1.5f);
            isHit = true;
            nav.velocity = Vector3.zero;
            nav.isStopped = true;
        }

    }
    public override void UpdateTarget()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 17f);

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
            if (isHit)//타격시 이동제어
            {
                nav.isStopped = true;
                nav.velocity = Vector3.zero;
            }
            else
            {
                nav.isStopped = false;
                nav.SetDestination(target.position);
                anim.SetBool("isWalk", true);
            }
        }
        else//플레이어가 범위안에 없을때,
        {
            anim.SetBool("isWalk", false);
            nav.velocity = Vector3.zero;
            nav.isStopped = true;

        }
    }
    public override void FixedUpdate()
    {
        if (curHealth > 0)
        {
            PlayerTargetSlime();
        }
    }
    void PlayerTargetSlime()
    {
        float TargetRadius = 0.5f;
        float TargetRange = 1.2f;
        RaycastHit[] rayHits =
            Physics.SphereCastAll(transform.position,
                                   TargetRadius,
                                   transform.forward,
                                   TargetRange,
                                   LayerMask.GetMask("Player")
                                   );
        if (rayHits.Length > 0 && !isAttack_ && curHealth > 0 && !isHit)//공격중이 아니면서 범위 안에 들어왔다
        {
            StartCoroutine(SlimeAttack());
        }
    }
    IEnumerator SlimeAttack()
    {
        if (curHealth > 0)
        {
            isHit = true;
            isAttack_ = true;
            anim.SetBool("isAttack", true);
            yield return new WaitForSeconds(0.5f);
            meleeArea_.enabled = true;
            yield return new WaitForSeconds(0.1f);
            meleeArea_.enabled = false;
            yield return new WaitForSeconds(0.5f);

            isHit = false;
            isAttack_ = false;
            anim.SetBool("isAttack", false);
        }
    }
}
