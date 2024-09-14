using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Panda;
namespace Panda.Examples.Move
{
    public class WizardBT : MonoBehaviour
    {
        public int maxHealth;
        public int curHealth;
        public GameObject Bullet; //�⺻����
        public GameObject Tornado;
        public GameObject Sheild;
        public Vector3 targetPos;
        public Transform HealPackPos;
        public Transform Player;
        //public bool isChase;
        //public bool isHit;
        //public bool monsterISHit;
        private NavMeshAgent nav;
        //(�񷽸���)���� 20221102
        public BoxCollider meleeArea_;
        public bool isAttack_;
        private Rigidbody rigid;
        BoxCollider boxCollider;
        private Animator anim;
        //���� ����AI
        //[SerializeField] Transform[] m_tfWayPoints = null;
        //int m_count = 0;

        //float speed = 1.0f; // current speed

        public virtual void Start()
        {
            //HealPackPos = new Vector3(20.0f, 0.0f, -20.0f);
            //isHit = false;
            //monsterISHit = false;
            maxHealth = 60;
            curHealth = 60;
            //target.position = new Vector3(0,0,0);
        }
        public virtual void Awake()
        {
            rigid = GetComponent<Rigidbody>();
            boxCollider = GetComponent<BoxCollider>();
            anim = GetComponentInChildren<Animator>();
            nav = GetComponent<NavMeshAgent>();
        }
        [Task]
        void Die()
        {
            if (GameManager.instance.BTWizardHP <= 0)
            {
                Debug.Log("DIE");
                ThisTask.Succeed();
            }
            else if (GameManager.instance.BTWizardHP > 0)
            {
                Debug.Log("NOTDIE");
                ThisTask.Fail();
            }

        }

        [Task]
        void Dead()
        {
           
            anim.SetTrigger("Die");            
            Destroy(gameObject, 0.8f);
            Debug.Log("�����");
            ThisTask.Succeed();
        }

        [Task]
        void Move(float x,float y,float z)
        {
            targetPos=new Vector3(x, y, z);
            //target.position = new Vector3(0, 0, 0);
            nav.SetDestination(targetPos);
            anim.SetBool("isWalk", true);
            if (Vector3.Distance(targetPos,this.transform.position)<1)
            {
                ThisTask.Succeed();
            }
            if(GameManager.instance.BTWizardHP == 0)
            {
                ThisTask.Fail();
            }

            Collider[] cols2 = Physics.OverlapSphere(transform.position, 30f);

            if (cols2.Length > 0)
            {

                for (int i = 0; i < cols2.Length; i++)
                {
                    if (cols2[i].tag == "Player")//�����ȿ� ������
                    {
                        nav.isStopped = true;                      
                        anim.SetBool("isWalk", false);
                        ThisTask.Fail();
                        break;
                    }
                    else//�����ȿ� ������
                    {
                        nav.isStopped = false;
                        //ThisTask.Fail();
                    }

                }
            }

        }
        [Task]
        void NotDectected()
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, 30f);

            if (cols.Length > 0)
            {

                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].tag == "Player")//�����ȿ� ������
                    {
                        //Debug.Log("Physics Enemy : Target found");
                        anim.SetBool("isWalk", true);
                        ThisTask.Fail();
                        break;
                    }
                    else//�����ȿ� ������
                    {
                        //ThisTask.Fail();
                        ThisTask.Succeed();
                    }

                }
            }
        }
        
        [Task]
        void isPlayerDectected()
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, 30f);
            if (cols.Length > 0)
            {

                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].tag == "Player")//�����ȿ� ������
                    {                       
                        ThisTask.Succeed();
                        break;
                    }
                    else//�����ȿ� ������
                    {
                        ThisTask.Fail();
                    }
                }
            }
        }

        [Task]
        void Chase()
        {
            nav.SetDestination(Player.position);
            nav.isStopped = false;
            anim.SetBool("isWalk", true);
            ThisTask.Succeed();
            Collider[] cols = Physics.OverlapSphere(transform.position, 20f);
            if (cols.Length > 0)
            {

                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].tag == "Player")//�����ȿ� ������
                    {
                        nav.isStopped = true;
                        anim.SetBool("isWalk", false);
                        ThisTask.Fail();
                        break;
                    }
                    else
                    {
                        anim.SetBool("isAttack", false);
                    }
                }
            }
        }

        [Task]
        void inAttackArea()
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, 20f);
            if (cols.Length > 0)
            {

                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].tag == "Player")//�����ȿ� ������
                    {
                        //nav.isStopped = true;
                        //anim.SetBool("isWalk", false);
                        ThisTask.Succeed();
                        break;
                    }
                    else
                    {
                        anim.SetBool("isAttack", false);
                    }
                }
            }
        }
        [Task]
        void ManyHP()
        {
            if (GameManager.instance.BTWizardHP > 50)
            {
                ThisTask.Succeed();
            }
            else
            {
                anim.SetBool("isAttack", false);
                ThisTask.Fail();
            }
                    
        }
        
        [Task]
        void DefaultAttack()
        {
            StartCoroutine(WizardAttack());
            ThisTask.Succeed();
            //nav.isStopped = true;
            //anim.SetBool("isWalk", false);
            Sheild.SetActive(false);
        }

        IEnumerator WizardAttack()
        {
            nav.isStopped = false;
            anim.SetBool("isWalk", true);
            nav.SetDestination(Player.position);
            anim.SetBool("isAttack", true);
          
            GameObject instantBullet = Instantiate(Bullet, transform.position, transform.rotation);
            Rigidbody rigidBullet = instantBullet.GetComponent<Rigidbody>();
            rigidBullet.velocity = transform.forward * 20;

            yield return null;
            
            //anim.SetBool("isAttack", false);
            //yield return new WaitForSeconds(0.1f);
            //anim.SetBool("isAttack", false);
        }
        [Task]
        void HalfHP()
        {
            if (GameManager.instance.BTWizardHP <= 50&& GameManager.instance.BTWizardHP > 20)
            {
                ThisTask.Succeed();
            }
            else
            {
                anim.SetBool("isAttack", false);
                ThisTask.Fail();
            }

        }
        [Task]
        void Barrier()
        {
            nav.isStopped = false;
            anim.SetBool("isWalk", true);
            nav.SetDestination(Player.position);
            Sheild.SetActive(true);
            ThisTask.Succeed();
        }

        [Task]
        void TornadoAttack()
        {
            StartCoroutine(SkillAttack());
            ThisTask.Succeed();
            //nav.isStopped = true;
            //anim.SetBool("isWalk", false);
            Sheild.SetActive(false);
        }

        IEnumerator SkillAttack()
        {
            nav.isStopped = false;
            anim.SetBool("isWalk", true);
            nav.SetDestination(Player.position);
            anim.SetBool("isSkillAtack", true);

            GameObject instantTornado = Instantiate(Tornado, transform.position, transform.rotation);
            Rigidbody rigidTornado = instantTornado.GetComponent<Rigidbody>();
            rigidTornado.velocity = transform.forward * 10;

            //yield return null;

            //anim.SetBool("isAttack", false);
            yield return new WaitForSeconds(0.7f);
            //anim.SetBool("isAttack", false);
            anim.SetBool("isSkillAtack", false);
        }

        [Task]
        void LowHP()
        {
            if (GameManager.instance.BTWizardHP <= 20 && GameManager.instance.BTWizardHP > 0)
            {
                nav.isStopped = false;
                ThisTask.Succeed();
            }
            else
            {
                anim.SetBool("isAttack", false);
                ThisTask.Fail();
            }
        }
        [Task]
        void RunAway()
        {
            nav.SetDestination(new Vector3(20,2,-20));
            anim.SetBool("isWalk", true);
            if (Vector3.Distance(new Vector3(20, 2, -20), this.transform.position) < 2)
            {
                ThisTask.Succeed();
            }
            if (GameManager.instance.BTWizardHP <= 0)
            {
                ThisTask.Fail();
            }
           

            
            
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.tag == "DefaultAttack")
        //    {
        //        DefaultAttack bullet = other.GetComponent<DefaultAttack>();
        //        curHealth -= bullet.damage;
        //        Debug.Log(curHealth);
        //    }
        //    //20221012 �ʻ�� ������
        //    if (other.tag == "SpecialAttack")
        //    {
        //        SpecialMove EnergyWave = other.GetComponent<SpecialMove>();       //SpecialMove ��ũ��Ʈ���� Specialmove ������Ʈ ��������.
        //        curHealth -= EnergyWave.Specialdamage;
        //        //StartCoroutine(WDamaged());
        //    }
        //}

    }
}
