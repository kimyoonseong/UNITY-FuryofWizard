using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.AI;
public class EndingPlayer : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent nav;
    public Animator anim;
    public GameObject Panel;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Portal").transform;
       
    }
    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(target.position);
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("Walk",true)  ;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position,target.position)<3)
        {
           // Debug.Log(target.transform.position);
            anim.SetBool("Walk",false) ;
        }
        else anim.SetBool("Walk", true);
        this.GetComponent<StarterAssetsInputs>().SetCursorState(false);
        this.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            Panel.SetActive(true);
            //StartCoroutine(FadeCoroutine());
        }
    }
   
}
