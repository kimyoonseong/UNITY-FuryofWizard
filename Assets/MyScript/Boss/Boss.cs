using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StarterAssets;
using UnityEngine.SceneManagement;
using Panda;
namespace Panda.Examples.Move
{
    public class Boss : MonoBehaviour
    {
       
        public GameObject Bullet;// 마왕 기본공격
        public GameObject Tornado;//마왕 기본공격2
        public GameObject Beam; //마왕 추적공격
        //public GameObject skeleton;//마왕 몹 소환
        public Vector3 targetPos;
        public Transform Player;
        public GameObject Spawner;
        public GameObject LavaSpawner;
        //public Transform Skeleton1;//스켈레톤 소환위치

        private NavMeshAgent nav;
        public bool isAttack_;
        private Rigidbody rigid;
        BoxCollider boxCollider;
        private Animator anim;

        // Start is called before the first frame update
        void Start()
        {
           
        }
        public virtual void Awake()
        {
            rigid = GetComponent<Rigidbody>();
            boxCollider = GetComponent<BoxCollider>();
            anim = GetComponentInChildren<Animator>();
            nav = GetComponent<NavMeshAgent>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "DefaultAttack")
            {
                GameManager.instance.BossHP -= 10;
                //anim.SetTrigger("GetHit");

            }
            else if (other.tag == "SpecialAttack")
            {
                GameManager.instance.BossHP -= 20;
            }
        }
        
        [Task]
        void isDie()
        {
            if (GameManager.instance.BossHP <= 0)
            {
                Debug.Log("DIE");
                ThisTask.Succeed();
                GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(true);
                GameObject.Find("Player").GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
            }
            else if (GameManager.instance.BossHP > 0)
            {
                ThisTask.Fail();
            }
        }
        [Task]
        void Dead()
        {

            anim.SetTrigger("Die");
            Destroy(gameObject, 3f);
            Debug.Log("실행됨");
            ThisTask.Succeed();
        }
        [Task]
        void Scenechange()
        {
            SceneManager.LoadScene("EndingScene");
        }

        [Task]
        void Attack()
        {
            StartCoroutine(BossAttack());
            ThisTask.Succeed();
            
        }
        IEnumerator BossAttack()
        {
            nav.isStopped = false;
            anim.SetBool("isWalk", true);
            nav.SetDestination(Player.position);

            yield return new WaitForSeconds(0.3f);
            nav.isStopped = true;
            anim.SetBool("isDefAttack", true);
            //anim.SetBool("isWalk", false);


            GameObject instantBullet = Instantiate(Bullet, transform.position, transform.rotation);
            Rigidbody rigidBullet = instantBullet.GetComponent<Rigidbody>();
            rigidBullet.velocity = transform.forward * 20;
            yield return new WaitForSeconds(0.7f);
            anim.SetBool("isDefAttack", false);
            //anim.SetBool("isWalk", true);

            yield return null;
        }

        [Task]
        void isPlayerDectected()
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, 20f);
            if (cols.Length > 0)
            {

                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].tag == "Player")//범위안에 있을때
                    {
                        ThisTask.Succeed();
                        break;
                    }
                    else//범위안에 없을때
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
            Collider[] cols = Physics.OverlapSphere(transform.position, 25f);
            if (cols.Length > 0)
            {

                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].tag == "Player")//범위안에 있을때
                    {
                        nav.isStopped = true;
                        //anim.SetBool("isWalk", false);
                        ThisTask.Fail();
                        break;
                    }
                    else
                    {
                        //anim.SetBool("isAttack", false);
                    }
                }
            }
        }
        [Task]
        void Spawn()
        {
            Spawner.GetComponent<skeletonSP>().Spaw();
            //StartCoroutine(SkeletonSpawner());
            ThisTask.Succeed();
        }
        [Task]
        void inAttackArea()
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, 25f);
            if (cols.Length > 0)
            {

                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].tag == "Player")//범위안에 있을때
                    {
                        //nav.isStopped = true;
                        //anim.SetBool("isWalk", false);
                        ThisTask.Succeed();
                        break;
                    }
                    else
                    {
                        anim.SetBool("isDefAttack", false);
                    }
                }
            }
        }
        [Task]
        void SkillAttack()
        {
            StartCoroutine(BossSkillAttack());
            //anim.SetBool("isDefAttack2", true);
            //Instantiate(Tornado, transform.position, transform.rotation);
            ThisTask.Succeed();
        }
        IEnumerator BossSkillAttack()
        {
            nav.isStopped = false;
            anim.SetBool("isWalk", true);
            nav.SetDestination(Player.position);

            yield return new WaitForSeconds(0.1f);
            nav.isStopped = true;
            anim.SetBool("isDefAttack2", true);
            yield return new WaitForSeconds(0.7f);
            Instantiate(Tornado, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.3f);
            anim.SetBool("isDefAttack2", false);

            yield return null;
        }

        [Task]
        void ManyHP()
        {
            if (GameManager.instance.BossHP > 90)
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
        void HalfHP()
        {
            if (GameManager.instance.BossHP > 50)
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
        void LowHP()
        {
            if (GameManager.instance.BossHP > 0)
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
        void LavaAttack()
        {
            LavaSpawner.GetComponent<LavaSpawn>().Spaw();
            //StartCoroutine(SkeletonSpawner());
            ThisTask.Succeed();
        }


        [Task]
        void FollowingAttack()
        {
            StartCoroutine(FollowAttack());
            ThisTask.Succeed();

        }

        IEnumerator FollowAttack()
        {
            nav.isStopped = false;
            anim.SetBool("isWalk", true);
            nav.SetDestination(Player.position);

            yield return new WaitForSeconds(0.3f);
            nav.isStopped = true;
            anim.SetBool("isDefAttack", true);
            //anim.SetBool("isWalk", false);

            Instantiate(Beam, transform.position, transform.rotation);
            //GameObject instantBullet = Instantiate(Beam, transform.position, transform.rotation);
            //Rigidbody rigidBullet = instantBullet.GetComponent<Rigidbody>();
            //rigidBullet.velocity = transform.forward * 20;
            yield return new WaitForSeconds(0.7f);
            anim.SetBool("isDefAttack", false);
            //anim.SetBool("isWalk", true);

            yield return null;
        }











    }


   

}

