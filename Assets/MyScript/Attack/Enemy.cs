using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//20221005 enemy ü�� ����
public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;


    //��������20221018
    public Transform target;
    public bool isChase;
    public bool isHit;
    public bool monsterISHit;
    protected NavMeshAgent nav;
    //(�񷽸���)���� 20221102
    public BoxCollider meleeArea_;
    public bool isAttack_;
    protected Rigidbody rigid;
    BoxCollider boxCollider;
    protected Animator anim;
    //���� ����AI
    [SerializeField] Transform[] m_tfWayPoints = null;
    int m_count = 0;

    //Material mat;
    public virtual void Start()
    {
        isHit = false;
        monsterISHit = false;
        maxHealth = 60;
        curHealth =60;       
        InvokeRepeating("UpdateTarget", 0f, 0.8f);//�� 0.25�ʸ��� Ÿ�� üũ
    }
   
    public virtual void Update()
    {

        
        
      
    }
    public virtual void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();      
        anim = GetComponentInChildren<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    public virtual void OnTriggerEnter(Collider other)
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
        monsterISHit = true;
        nav.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
       
        if (curHealth > 0)
        {
            
            anim.SetTrigger("Hit");
            yield return new WaitForSeconds(0.5f);           
            isHit = false;
            
        }
        else if(curHealth<=0)
        {
            transform.Find("collider").gameObject.SetActive(false);
            transform.Find("Attackcollider").gameObject.SetActive(false);
            anim.SetTrigger("Die");
            Destroy(gameObject,0.8f);           
            isHit = true;
            nav.velocity = Vector3.zero;
            nav.isStopped = true;
            yield return new WaitForSeconds(2.5f);
            monsterISHit = false;
        }
        yield return new WaitForSeconds(0.5f);
        monsterISHit = false;
    }
    //����ai
    void MoveToNextWayPoint()
    {
        anim.SetBool("isWalk", true);
        nav.SetDestination(m_tfWayPoints[m_count++].position);
        if (m_count >= m_tfWayPoints.Length)
        {
            m_count = 0;
        }
    }


    //�÷��̾� ���ٽ� ����
    public virtual void UpdateTarget()
    {

        Collider[] cols = Physics.OverlapSphere(transform.position, 13f);
       
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
            //anim.SetBool("isWalk", false);
            //nav.velocity = Vector3.zero;
            //nav.isStopped = true;
            MoveToNextWayPoint();
        }

    }


    public virtual void FixedUpdate()
    {
        Targeting();
    }
    void Targeting()//�����ȿ� �÷��̾� ��������
    {
        float targetRadius = 2.0f;
        float targetRange = 3f;
        RaycastHit[] rayHits =
            Physics.SphereCastAll(transform.position,
                                   targetRadius,
                                   transform.forward,
                                   targetRange,
                                   LayerMask.GetMask("Player")
                                   );
        if (rayHits.Length > 0 && !isAttack_ && curHealth > 0&& !monsterISHit)//�������� �ƴϸ鼭 ���� �ȿ� ���Դ�
        {
            Debug.Log("monattack");
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        isHit = true;
        isAttack_ = true;
        anim.SetBool("isAttack", true);

        yield return new WaitForSeconds(0.5f);
        meleeArea_.enabled = true;
        yield return new WaitForSeconds(0.1f);
        meleeArea_.enabled = false;
        yield return new WaitForSeconds(0.3f);
        //yield return new WaitForSeconds(1f);
        isHit = false;
        isAttack_ = false;
        anim.SetBool("isAttack", false);
    }
    
}
