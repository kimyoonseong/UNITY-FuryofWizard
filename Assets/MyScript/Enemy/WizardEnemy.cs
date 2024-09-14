using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardEnemy : Enemy
{
    //20221103원거리공격
    public GameObject Bullet;
    public override void Start()
    {
        base.Start();
        maxHealth =20;
        curHealth = 20;
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
            DefaultAttack bullet = other.GetComponent<DefaultAttack>();
            curHealth -= bullet.damage;
            StartCoroutine(WDamaged());


        }
        //20221012 필살기 데미지
        if (other.tag == "SpecialAttack")
        {
            SpecialMove EnergyWave = other.GetComponent<SpecialMove>();       //SpecialMove 스크립트에서 Specialmove 컴포넌트 가져오기.
            curHealth -= EnergyWave.Specialdamage;

            StartCoroutine(WDamaged());
        }
    }
    IEnumerator WDamaged()
    {
        isHit = true;
        //monsterISHit = true;
        nav.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.1f);

        if (curHealth > 0)
        {

            anim.SetTrigger("Hit");
            yield return new WaitForSeconds(0.5f);
            isHit = false;

        }
        else if (curHealth <= 0)
        {
            //transform.Find("collider").gameObject.SetActive(false);
            //transform.Find("Attackcollider").gameObject.SetActive(false);
            anim.SetTrigger("Die");
            Destroy(gameObject, 0.8f);
            isHit = true;
            nav.velocity = Vector3.zero;
            nav.isStopped = true;
            yield return new WaitForSeconds(2.5f);
            //monsterISHit = false;
        }
        yield return new WaitForSeconds(0.5f);
        //monsterISHit = false;
    }
    public override void UpdateTarget()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 30f);

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
        PlayerTarget();
    }
    void PlayerTarget()
    {
        float TargetRadius = 0.5f;
        float TargetRange = 20f;
        RaycastHit[] rayHits =
            Physics.SphereCastAll(transform.position,
                                   TargetRadius,
                                   transform.forward,
                                   TargetRange,
                                   LayerMask.GetMask("Player")
                                   );
        if (rayHits.Length > 0 && !isAttack_ &&curHealth>0&& !isHit)//공격중이 아니면서 범위 안에 들어왔다
        {
            StartCoroutine(WizardAttack());
        }
    }
    IEnumerator WizardAttack()
    {
        isHit = true;
        isAttack_ = true;
        anim.SetBool("isAttack", true);

        //yield return new WaitForSeconds(0.5f);
        //GameObject bulletPackage = Instantiate(Bullet, transform.position, transform.rotation);
        //Transform[] childs = bulletPackage.GetComponentsInChildren<Transform>();
        //for (int i = 0; i < childs.Length; i++) //각 총알의 부모-자식 관계를 끊어줌
        //{
        //    childs[i].parent = null;
        //}
        //Destroy(bulletPackage);
        GameObject instantBullet = Instantiate(Bullet, transform.position, transform.rotation);
        Rigidbody rigidBullet = instantBullet.GetComponent<Rigidbody>();
        rigidBullet.velocity = transform.forward * 20;
        
        yield return new WaitForSeconds(1f);
        //meleeArea_.enabled = false;

        //yield return new WaitForSeconds(1f);
        isHit = false;
        isAttack_ = false;
        anim.SetBool("isAttack", false);
    }
}
