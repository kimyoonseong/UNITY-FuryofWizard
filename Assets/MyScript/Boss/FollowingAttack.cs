using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowingAttack : MonoBehaviour
{
    private NavMeshAgent nav;
    public Transform Player;
    public GameObject Player1;
    // Start is called before the first frame update
    public  void Awake()
    {     
        nav = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        Player1 = GameObject.Find("Player");
        Player = Player1.transform;
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(Player.position);
    }
}
