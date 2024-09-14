using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardEnemy : Enemy
{
    //20221103���Ÿ�����
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
        //20221012 �ʻ�� ������
        if (other.tag == "SpecialAttack")
        {
            SpecialMove EnergyWave = other.GetComponent<SpecialMove>();       //SpecialMove ��ũ��Ʈ���� Specialmove ������Ʈ ��������.
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
            if (isHit)//Ÿ�ݽ� �̵�����
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
        else//�÷��̾ �����ȿ� ������,
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
        if (rayHits.Length > 0 && !isAttack_ &&curHealth>0&& !isHit)//�������� �ƴϸ鼭 ���� �ȿ� ���Դ�
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
        //for (int i = 0; i < childs.Length; i++) //�� �Ѿ��� �θ�-�ڽ� ���踦 ������
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
